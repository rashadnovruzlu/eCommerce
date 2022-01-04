using eCommerce.SharedKernel;
using System.Linq.Expressions;

namespace eCommerce.Application;

public class BaseEntityService<T> : IEntityService<T> where T : class
{
    public int Culture
    {
        get
        {
            string culture = Thread.CurrentThread.CurrentCulture.Name;

            return Language.Find(culture).Value;
        }
    }


    private readonly IRepository<T> _repository;

    public BaseEntityService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public void Add(T entity, bool isCommit = true)
    {
        _repository.Add(entity, isCommit);
    }

    public async Task AddAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = new CancellationToken())
    {
        await _repository.AddAsync(entity, isCommit, cancellationToken);
    }

    public void AddRange(IEnumerable<T> entities, bool isCommit = true)
    {
        _repository.AddRange(entities, isCommit);
    }

    public void Attach(T entity) => _repository.Attach(entity);

    public void AttachRange(IEnumerable<T> entities) => _repository.AttachRange(entities);


    public void Delete(T entity, bool isCommit = true)
    {
        _repository.Delete(entity, isCommit);
    }

    public async Task DeleteAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = new CancellationToken())
    {
        await _repository.DeleteAsync(entity, isCommit, cancellationToken);
    }

    public void DeleteRange(IEnumerable<T> entities, bool isCommit = true)
    {
        _repository.DeleteRange(entities, isCommit);

    }

    public void Update(T entity, bool isCommit = true)
    {
        _repository.Update(entity, isCommit);
    }


    public async Task UpdateAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = new CancellationToken())
    {
        await _repository.UpdateAsync(entity, isCommit, cancellationToken);
    }

    public async Task<int> SaveChangesAsync(bool isCommit = true, CancellationToken cancellationToken = new CancellationToken()) => await _repository.SaveChangesAsync(isCommit, cancellationToken);

    public int Save(bool isCommit = true) => _repository.Save(isCommit);

    public T Find(Expression<Func<T, bool>> match) => _repository.Find(match);

    public ICollection<T> FindAll(Expression<Func<T, bool>> match) => _repository.FindAll(match).ToList();

    public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default)
    {
        var result = await _repository.FindAllAsync(match, cancellationToken);
        return result;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default)
    {
        var result = await _repository.FirstOrDefaultAsync(match, cancellationToken);
        return result;
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => _repository.FindBy(predicate);

    public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await _repository.FindByAsync(predicate, cancellationToken);
        return result;
    }

    public T Get(object id) => _repository.Get(id);

    public IQueryable<T> GetAll() => _repository.GetAll();

    public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result;
    }

    public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(id, cancellationToken);
        return result;
    }

    public IQueryable<T> IncludeMany(params Expression<Func<T, object>>[] includes)
    {
        return _repository.IncludeMany(includes);
    }

    public IQueryable<T> IncludeMany(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        return _repository.IncludeMany(predicate, includes);
    }


    public IQueryable<T> Filter(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page, int pageSize)
    {
        IQueryable<T> query = _repository.GetAll();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        return query;
    }

    public IQueryable<K> Filter<K>(IQueryable<K> query, Expression<Func<K, bool>> filter, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, int page, int pageSize)
    {

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        return query;
    }

    public void UpdateSpecialProperties(T entity, bool isCommit = true, params Expression<Func<T, object>>[] properties)
    {
        _repository.UpdateSpecialProperties(entity, isCommit, properties);
    }

    public void UpdateExceptedProperties(T entity, bool isCommit = false, params Expression<Func<T, object>>[] properties)
    {
        _repository.UpdateExceptedProperties(entity, isCommit, properties);
    }

    protected IQueryable<K> AddFilter<K>(IQueryable<K> query, PagingRequest pagingRequest)
    {
        foreach (var filter in pagingRequest.Filters)
        {
            string body = string.Empty;

            if (filter.EqualityType == "StartsWith")
            {
                body = $"{ filter.FieldName}.StartsWith({ filter.Value})";
            }
            else if (filter.EqualityType == "Contains")
            {
                body = $"{ filter.FieldName}.Contains({ filter.Value})";

            }
            else if (filter.EqualityType == "Equal")
            {
                body = $"{ filter.FieldName}={ filter.Value}";
            }

            query = query.WhereDynamic($"x => x.{body}");
        }

        return query;
    }
}
