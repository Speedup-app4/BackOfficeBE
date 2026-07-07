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
            Guid clientId,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        );
        Task<IEnumerable<T>> GetByIdsAsync<TId>(
            IEnumerable<TId> ids,
            Guid clientId,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        );
        Task<IEnumerable<T>> GetAllAsync(
            Guid clientId,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        );
        Task<int> CountAllAsync(
            Guid clientId,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        );
    }
}
