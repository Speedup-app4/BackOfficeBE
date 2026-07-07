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
            Guid? clientId = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        );
        Task<IEnumerable<T>> GetByIdsAsync<TId>(
            IEnumerable<TId> ids,
            Guid? clientId = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        );
        Task<IEnumerable<T>> GetAllAsync(
            Guid? clientId = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        );
        Task<int> CountAllAsync(CancellationToken cancellationToken = default);
    }
}
