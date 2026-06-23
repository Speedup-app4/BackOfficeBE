namespace BackOffice.Interfaces.Base
{
    public interface IGenericRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class { }
}
