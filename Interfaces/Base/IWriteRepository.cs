namespace BackOffice.Interfaces.Base
{
    public interface IWriteRepository<T>
        where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<int> AddRangeAsync(
            IEnumerable<T> entities,
            CancellationToken cancellationToken = default
        );
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdatePartialAsync(
            object updateDto,
            object idValue,
            Guid? clientId = null,
            Guid? storeId = null,
            CancellationToken cancellationToken = default
        );
        Task<int> UpdatePartialRangeAsync<TUpdateDto>(
            IEnumerable<TUpdateDto> updateDtos,
            Guid? clientId = null,
            Guid? storeId = null,
            CancellationToken cancellationToken = default
        );
        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}
