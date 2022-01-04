using System.Linq.Expressions;

namespace eCommerce.Application;

public interface IEntityService<T> where T : class
{
    void Add(T entity, bool isCommit = true);
    Task AddAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = default);
    void AddRange(IEnumerable<T> entities, bool isCommit = true);
    void Attach(T entity);
    void AttachRange(IEnumerable<T> entities);
    void Delete(T entity, bool isCommit = true);
    Task DeleteAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = default);
    void DeleteRange(IEnumerable<T> entities, bool isCommit = true);
    void Update(T entity, bool isCommit = true);
    Task UpdateAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = default);
    int Save(bool isCommit = true);
    Task<int> SaveChangesAsync(bool isCommit = true, CancellationToken cancellationToken = new CancellationToken());

    T Find(Expression<Func<T, bool>> match);
    ICollection<T> FindAll(Expression<Func<T, bool>> match);
    Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default);
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default);
    T Get(object id);
    IQueryable<T> GetAll();
    Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> GetAsync(object id, CancellationToken cancellationToken = default);
    IQueryable<T> IncludeMany(params Expression<Func<T, object>>[] includes);
    IQueryable<T> IncludeMany(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    IQueryable<T> Filter(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page, int pageSize);
    IQueryable<K> Filter<K>(IQueryable<K> query, Expression<Func<K, bool>> filter, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, int page, int pageSize);
    void UpdateSpecialProperties(T entity, bool isCommit = true, params Expression<Func<T, object>>[] properties);
    void UpdateExceptedProperties(T entity, bool isCommit = false, params Expression<Func<T, object>>[] properties);
}
