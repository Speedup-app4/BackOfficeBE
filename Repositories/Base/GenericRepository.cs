using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BackOffice.Interfaces.Base;
using Dapper;
using Npgsql;

namespace BackOffice.Repositories.Base;

public class GenericRepository<T>(IUnitOfWork uow) : IGenericRepository<T>
    where T : class
{
    private static readonly ConcurrentDictionary<Type, string> _tableNameCache = new();
    private static readonly ConcurrentDictionary<Type, string> _keyColumnNameCache = new();
    private static readonly ConcurrentDictionary<Type, string> _keyPropertyNameCache = new();
    private static readonly ConcurrentDictionary<(Type, bool), string> _columnsCache = new();
    private static readonly ConcurrentDictionary<(Type, bool), string> _columnsAsPropertiesCache =
        new();
    private static readonly ConcurrentDictionary<(Type, bool), string> _propertyNamesCache = new();
    private static readonly ConcurrentDictionary<
        (Type, bool),
        IEnumerable<PropertyInfo>
    > _propertiesCache = new();

    private static readonly ConcurrentDictionary<Type, string?> _isActiveColumnNameCache = new();
    private static readonly ConcurrentDictionary<Type, string?> _isActivePropertyNameCache = new();

    protected readonly IUnitOfWork _uow = uow;

    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            string? keyProperty = GetKeyPropertyName();
            if (!string.IsNullOrEmpty(keyProperty))
            {
                var propInfo = typeof(T).GetProperty(keyProperty);
                if (propInfo != null)
                {
                    if (
                        propInfo.PropertyType == typeof(Guid)
                        || propInfo.PropertyType == typeof(Guid?)
                    )
                    {
                        var currentValue = propInfo.GetValue(entity);
                        if (
                            currentValue == null
                            || (currentValue is Guid guid && guid == Guid.Empty)
                        )
                        {
                            propInfo.SetValue(entity, Guid.NewGuid());
                        }
                    }
                }
            }

            string tableName = GetTableName();
            string columns = GetColumns(excludeKey: false);
            string properties = GetPropertyNames(excludeKey: false);

            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties}) RETURNING *";

            return await _uow.Connection.QuerySingleAsync<T>(query, entity, _uow.Transaction);
        }
        catch (PostgresException ex)
        {
            HandlePostgresException(ex);
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"System error while inserting data into {typeof(T).Name}: {ex.Message}",
                ex
            );
        }
    }

    public virtual async Task<int> AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default
    )
    {
        if (entities == null || !entities.Any())
            return 0;

        try
        {
            string tableName = GetTableName();
            string columns = GetColumns(excludeKey: false);
            string properties = GetPropertyNames(excludeKey: false);

            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";

            return await _uow.Connection.ExecuteAsync(query, entities, _uow.Transaction);
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"System error while bulk inserting into {typeof(T).Name}: {ex.Message}",
                ex
            );
        }
    }

    public virtual async Task<int> CountAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            string tableName = GetTableName();
            string query = $"SELECT COUNT(*) FROM {tableName}";

            return await _uow.Connection.QueryFirstOrDefaultAsync<int>(
                query,
                transaction: _uow.Transaction
            );
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to count data for {typeof(T).Name}.", ex);
        }
    }

    public virtual async Task<int> DeleteAsync(
        T entity,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            string? tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();
            string? keyProperty = GetKeyPropertyName();

            string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";

            return await _uow.Connection.ExecuteAsync(query, entity, _uow.Transaction);
        }
        catch (PostgresException ex)
        {
            HandlePostgresException(ex);
            return -1;
        }
        catch (Exception ex)
        {
            throw new Exception($"System error while deleting {typeof(T).Name}: {ex.Message}", ex);
        }
    }

    public virtual Task<(IEnumerable<T>, int)> GetPagedAsync()
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(
        bool? isActive = true,
        Guid? clientId = null,
        Guid? storeId = null,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            string tableName = GetTableName();
            string columns = GetColumnsAsProperties();

            string query = $"SELECT {columns} FROM {tableName}";

            var parameters = new DynamicParameters();
            var conditions = new List<string>();

            string? isActiveColumn = GetIsActiveColumnName();
            if (isActiveColumn != null && isActive.HasValue)
            {
                conditions.Add($"{isActiveColumn} = @IsActiveVal");
                parameters.Add("@IsActiveVal", isActive.Value ? 1 : 0);
            }

            if (clientId.HasValue)
            {
                conditions.Add("\"ClientId\" = @ClientId");
                parameters.Add("@ClientId", clientId.Value);
            }

            if (storeId.HasValue)
            {
                conditions.Add("\"StoreId\" = @StoreId");
                parameters.Add("@StoreId", storeId.Value);
            }

            if (conditions.Count > 0)
                query += " WHERE " + string.Join(" AND ", conditions);

            var result = await _uow.Connection.QueryAsync<T>(query, parameters, _uow.Transaction);
            return [.. result];
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to fetch data for {typeof(T).Name}: {ex.Message}", ex);
        }
    }

    public virtual async Task<IEnumerable<T>> GetByIdsAsync<TId>(
        IEnumerable<TId> ids,
        bool? isActive = null,
        Guid? clientId = null,
        Guid? storeId = null,
        CancellationToken cancellationToken = default
    )
    {
        if (ids == null || !ids.Any())
            return [];

        try
        {
            string tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();

            string query =
                $"SELECT {GetColumnsAsProperties()} FROM {tableName} WHERE {keyColumn} = ANY(@Ids)";

            var parameters = new DynamicParameters();
            parameters.Add("@Ids", ids.ToArray());

            string? isActiveColumn = GetIsActiveColumnName();
            if (isActive.HasValue && isActiveColumn != null)
            {
                query += $" AND {isActiveColumn} = @IsActiveVal";
                parameters.Add("@IsActiveVal", isActive.Value ? 1 : 0);
            }

            if (clientId.HasValue)
            {
                query += " AND \"ClientId\" = @ClientId";
                parameters.Add("@ClientId", clientId.Value);
            }

            if (storeId.HasValue)
            {
                query += " AND \"StoreId\" = @StoreId";
                parameters.Add("@StoreId", storeId.Value);
            }

            return await _uow.Connection.QueryAsync<T>(query, parameters, _uow.Transaction);
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"System error while fetching list of {typeof(T).Name}: {ex.Message}",
                ex
            );
        }
    }

    public virtual async Task<T?> GetByIdAsync(
        object id,
        bool? isActive = null,
        Guid? clientId = null,
        Guid? storeId = null,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            string tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();

            string query =
                $"SELECT {GetColumnsAsProperties()} FROM {tableName} WHERE {keyColumn} = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            string? isActiveColumn = GetIsActiveColumnName();
            if (isActive.HasValue && isActiveColumn != null)
            {
                query += $" AND {isActiveColumn} = @IsActiveVal";
                parameters.Add("@IsActiveVal", isActive.Value ? 1 : 0);
            }

            if (clientId.HasValue)
            {
                query += " AND \"ClientId\" = @ClientId";
                parameters.Add("@ClientId", clientId.Value);
            }

            if (storeId.HasValue)
            {
                query += " AND \"StoreId\" = @StoreId";
                parameters.Add("@StoreId", storeId.Value);
            }

            return await _uow.Connection.QueryFirstOrDefaultAsync<T>(
                query,
                parameters,
                _uow.Transaction
            );
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Unable to fetch detailed data for {typeof(T).Name}: {ex.Message}",
                ex
            );
        }
    }

    public virtual async Task<T> UpdateAsync(
        T entity,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            string? tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();
            string? keyProperty = GetKeyPropertyName();

            StringBuilder query = new();
            query.Append($"UPDATE {tableName} SET ");

            foreach (var property in GetProperties(true))
            {
                var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
                string propertyName = property.Name;

                string columnName = Quote(columnAttribute?.Name ?? propertyName);

                query.Append($"{columnName} = @{propertyName},");
            }

            query.Remove(query.Length - 1, 1);
            query.Append($" WHERE {keyColumn} = @{keyProperty}");

            int rowsEffected = await _uow.Connection.ExecuteAsync(
                query.ToString(),
                entity,
                _uow.Transaction
            );

            if (rowsEffected == 0)
                throw new Exception("No record was found to update.");

            return entity;
        }
        catch (PostgresException ex)
        {
            HandlePostgresException(ex);
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception($"System error while updating {typeof(T).Name}: {ex.Message}", ex);
        }
    }

    public virtual async Task<T> UpdatePartialAsync(
        object updateDto,
        object idValue,
        Guid? clientId = null,
        Guid? storeId = null,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            string? tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();
            string? keyProperty = GetKeyPropertyName();

            var query = new StringBuilder($"UPDATE {tableName} SET ");
            var parameters = new DynamicParameters();

            var whereConditions = new List<string> { $"{keyColumn} = @{keyProperty}" };

            parameters.Add($"@{keyProperty}", idValue);

            if (clientId.HasValue)
            {
                whereConditions.Add("\"ClientId\" = @WhereClientId");
                parameters.Add("@WhereClientId", clientId.Value);
            }

            if (storeId.HasValue)
            {
                whereConditions.Add("\"StoreId\" = @WhereStoreId");
                parameters.Add("@WhereStoreId", storeId.Value);
            }

            string whereClause = " WHERE " + string.Join(" AND ", whereConditions);

            bool hasFieldsToUpdate = false;
            var properties = updateDto.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<NotMappedAttribute>() != null)
                    continue;

                var value = property.GetValue(updateDto);
                if (value == null)
                    continue;

                string propertyName = property.Name;
                var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();

                string columnName = Quote(columnAttribute?.Name ?? propertyName);

                query.Append($"{columnName} = @{propertyName},");
                parameters.Add($"@{propertyName}", value);
                hasFieldsToUpdate = true;
            }

            if (!hasFieldsToUpdate)
            {
                var selectQuery = $"SELECT * FROM {tableName}{whereClause}";
                var existingEntity = await _uow.Connection.QuerySingleOrDefaultAsync<T>(
                    selectQuery,
                    parameters,
                    _uow.Transaction
                );
                return existingEntity ?? throw new Exception("No record was found.");
            }

            query.Length--;

            query.Append($"{whereClause} RETURNING *");

            var updatedEntity =
                await _uow.Connection.QuerySingleOrDefaultAsync<T>(
                    query.ToString(),
                    parameters,
                    _uow.Transaction
                )
                ?? throw new Exception(
                    "No record was found to update (ClientId/StoreId mismatch)."
                );
            return updatedEntity;
        }
        catch (PostgresException ex)
        {
            HandlePostgresException(ex);
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"System error while partial updating {typeof(T).Name}: {ex.Message}",
                ex
            );
        }
    }

    public virtual async Task<int> UpdatePartialRangeAsync<TUpdateDto>(
        IEnumerable<TUpdateDto> updateDtos,
        Guid? clientId = null,
        Guid? storeId = null,
        CancellationToken cancellationToken = default
    )
    {
        if (updateDtos == null || !updateDtos.Any())
            return 0;

        try
        {
            string? tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();
            string? keyProperty = GetKeyPropertyName();

            if (string.IsNullOrEmpty(keyProperty))
                throw new Exception($"Entity {typeof(T).Name} must have a [Key] attribute.");

            var firstItem = updateDtos.First();
            var query = new StringBuilder($"UPDATE {tableName} SET ");
            var properties = firstItem!.GetType().GetProperties();
            bool hasFieldsToUpdate = false;

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<NotMappedAttribute>() != null)
                    continue;

                string propertyName = property.Name;

                if (propertyName.Equals(keyProperty, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (
                    clientId.HasValue
                    && propertyName.Equals("ClientId", StringComparison.OrdinalIgnoreCase)
                )
                    continue;
                if (
                    storeId.HasValue
                    && propertyName.Equals("StoreId", StringComparison.OrdinalIgnoreCase)
                )
                    continue;

                var value = property.GetValue(firstItem);
                if (value == null)
                    continue;

                var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
                string columnName = Quote(columnAttribute?.Name ?? propertyName);

                query.Append($"{columnName} = @{propertyName},");
                hasFieldsToUpdate = true;
            }

            if (!hasFieldsToUpdate)
                return 0;

            query.Length--;

            var whereConditions = new List<string> { $"{keyColumn} = @{keyProperty}" };

            if (clientId.HasValue)
                whereConditions.Add("\"ClientId\" = @ClientId");

            if (storeId.HasValue)
                whereConditions.Add("\"StoreId\" = @StoreId");

            query.Append(" WHERE " + string.Join(" AND ", whereConditions));

            return await _uow.Connection.ExecuteAsync(
                query.ToString(),
                updateDtos,
                _uow.Transaction
            );
        }
        catch (PostgresException ex)
        {
            HandlePostgresException(ex);
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"System error while bulk partial updating {typeof(T).Name}: {ex.Message}",
                ex
            );
        }
    }

    #region Helper Methods

    protected void HandlePostgresException(PostgresException ex)
    {
        switch (ex.SqlState)
        {
            case "23505":
                string uniqueDetail = ex.Detail ?? "Duplicate data detected";
                throw new Exception($"Data duplication error: {uniqueDetail}", ex);

            case "23503":
                string fkDetail =
                    ex.Detail != null
                        ? $"Referenced data does not exist ({ex.Detail})"
                        : $"Foreign key constraint violation (Constraint: {ex.ConstraintName})";
                throw new Exception($"Data integrity error: {fkDetail}", ex);

            default:
                throw new Exception($"Database error ({ex.SqlState}): {ex.MessageText}", ex);
        }
    }

    private static string Quote(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        return $"\"{text}\"";
    }
    #endregion

    #region Table Attributes
    protected string GetTableName()
    {
        return _tableNameCache.GetOrAdd(
            typeof(T),
            type =>
            {
                var tableAttribute = type.GetCustomAttribute<TableAttribute>();
                string tableName = tableAttribute != null ? tableAttribute.Name : type.Name;
                return Quote(tableName);
            }
        );
    }

    protected string? GetKeyColumnName()
    {
        var columnName = _keyColumnNameCache.GetOrAdd(
            typeof(T),
            type =>
            {
                var keyProperty = GetProperties(excludeKey: false)
                    .FirstOrDefault(p => p.IsDefined(typeof(KeyAttribute), false));

                if (keyProperty == null)
                    return string.Empty;

                var columnAttribute = keyProperty.GetCustomAttribute<ColumnAttribute>();
                string name = columnAttribute?.Name ?? keyProperty.Name;
                return Quote(name);
            }
        );

        return string.IsNullOrEmpty(columnName) ? null : columnName;
    }

    protected string GetColumns(bool excludeKey = false)
    {
        return _columnsCache.GetOrAdd(
            (typeof(T), excludeKey),
            type =>
            {
                var columns = string.Join(
                    ", ",
                    GetProperties(type.Item2)
                        .Where(p => !p.IsDefined(typeof(NotMappedAttribute), false))
                        .Where(p => !type.Item2 || !p.IsDefined(typeof(KeyAttribute)))
                        .Select(p =>
                        {
                            var columnAttribute = p.GetCustomAttribute<ColumnAttribute>();
                            string name = columnAttribute?.Name ?? p.Name;
                            return Quote(name);
                        })
                );
                return columns;
            }
        );
    }

    protected string GetColumnsAsProperties(bool excludeKey = false)
    {
        return _columnsAsPropertiesCache.GetOrAdd(
            (typeof(T), excludeKey),
            type =>
            {
                var columnsAsProperties = string.Join(
                    ", ",
                    type.Item1.GetProperties()
                        .Where(p => !p.IsDefined(typeof(NotMappedAttribute), false))
                        .Where(p => !type.Item2 || !p.IsDefined(typeof(KeyAttribute)))
                        .Select(p =>
                        {
                            var columnAttribute = p.GetCustomAttribute<ColumnAttribute>();
                            string columnName = columnAttribute?.Name ?? p.Name;
                            return $"{Quote(columnName)} AS {Quote(p.Name)}";
                        })
                );
                return columnsAsProperties;
            }
        );
    }

    protected string GetPropertyNames(bool excludeKey = false)
    {
        return _propertyNamesCache.GetOrAdd(
            (typeof(T), excludeKey),
            type =>
            {
                var properties = type
                    .Item1.GetProperties()
                    .Where(p => !p.IsDefined(typeof(NotMappedAttribute), false))
                    .Where(p => !type.Item2 || p.GetCustomAttribute<KeyAttribute>() == null);

                var values = string.Join(", ", properties.Select(p => $"@{p.Name}"));
                return values;
            }
        );
    }

    protected IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
    {
        return _propertiesCache.GetOrAdd(
            (typeof(T), excludeKey),
            type =>
            {
                var properties = type
                    .Item1.GetProperties()
                    .Where(p => !p.IsDefined(typeof(NotMappedAttribute), false))
                    .Where(p => !type.Item2 || p.GetCustomAttribute<KeyAttribute>() == null);
                return properties;
            }
        );
    }

    protected string? GetKeyPropertyName()
    {
        var name = _keyPropertyNameCache.GetOrAdd(
            typeof(T),
            type =>
            {
                var keyProp = type.GetProperties()
                    .FirstOrDefault(p =>
                        !p.IsDefined(typeof(NotMappedAttribute), false)
                        && p.IsDefined(typeof(KeyAttribute), false)
                    );
                return keyProp?.Name ?? string.Empty;
            }
        );

        return string.IsNullOrEmpty(name) ? null : name;
    }

    protected string? GetIsActiveColumnName()
    {
        return _isActiveColumnNameCache.GetOrAdd(
            typeof(T),
            type =>
            {
                var prop = type.GetProperties()
                    .FirstOrDefault(p =>
                        p.Name.Equals("IsActive", StringComparison.OrdinalIgnoreCase)
                        && !p.IsDefined(typeof(NotMappedAttribute), false)
                    );

                if (prop == null)
                    return null;

                var columnAttribute = prop.GetCustomAttribute<ColumnAttribute>();
                string name = columnAttribute?.Name ?? prop.Name;
                return Quote(name);
            }
        );
    }

    protected string? GetIsActivePropertyName()
    {
        return _isActivePropertyNameCache.GetOrAdd(
            typeof(T),
            type =>
            {
                var prop = type.GetProperties()
                    .FirstOrDefault(p =>
                        p.Name.Equals("IsActive", StringComparison.OrdinalIgnoreCase)
                        && !p.IsDefined(typeof(NotMappedAttribute), false)
                    );

                return prop?.Name;
            }
        );
    }
    #endregion
}
