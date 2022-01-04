namespace eCommerce.Application;

public interface IUnitOfWork
{
    int Commit();
    Task<int> CommitAsync();
    int ExecuteSqlRaw(string sqlQuery);
    Task<int> ExecuteSqlRawAsync(string sqlQuery);
    void Rollback();
    Task RollbackAsync();
}
