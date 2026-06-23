using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackOffice.Interfaces.Base
{
    public interface IReadRepository<T>
        where T : class
    {
        Task<T?> GetByIdAsync(
            object id,
            bool? isActive = null,
            Guid? clientId = null,
            Guid? storeId = null,
            CancellationToken cancellationToken = default
        );
        Task<IEnumerable<T>> GetByIdsAsync<TId>(
            IEnumerable<TId> ids,
            bool? isActive = null,
            Guid? clientId = null,
            Guid? storeId = null,
            CancellationToken cancellationToken = default
        );
        Task<IEnumerable<T>> GetAllAsync(
            bool? isActive = true,
            Guid? clientId = null,
            Guid? storeId = null,
            CancellationToken cancellationToken = default
        );
        Task<int> CountAllAsync(CancellationToken cancellationToken = default);
    }
}
