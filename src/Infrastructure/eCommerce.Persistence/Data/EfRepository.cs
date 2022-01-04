using eCommerce.Application;
using eCommerce.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Persistence;

public class EfRepository<T> : IRepository<T> where T : class
{
    public int Culture
    {
        get
        {
            string culture = Thread.CurrentThread.CurrentCulture.Name;

            return Language.Find(culture).Value;
        }
    }

    private readonly DbContext _context;
    private DbSet<T> _dbSet;
    public virtual IQueryable<T> Table => _dbSet;
    public virtual IQueryable<T> TableNoTracking => _dbSet.AsNoTracking();

    public EfRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public void Add(T entity, bool isCommit = true)
    {
        _dbSet.Add(entity);
        Save(isCommit);
    }

    public async Task AddAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = new CancellationToken())
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await SaveChangesAsync(isCommit, cancellationToken);
    }

    public void AddRange(IEnumerable<T> entities, bool isCommit = true)
    {
        _dbSet.AddRange(entities);
        Save(isCommit);
    }

    public void Attach(T entity) => _dbSet.Attach(entity);

    public void AttachRange(IEnumerable<T> entities) => _dbSet.AttachRange(entities);

    public void Delete(T entity, bool isCommit = true)
    {
        _dbSet.Remove(entity);
        Save(isCommit);
    }

    public async Task DeleteAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = new CancellationToken())
    {
        _dbSet.Remove(entity);
        await SaveChangesAsync(isCommit, cancellationToken);
    }

    public void DeleteRange(IEnumerable<T> entities, bool isCommit = true)
    {
        _dbSet.RemoveRange(entities);
        Save(isCommit);
    }

    public void Update(T entity, bool isCommit = true)
    {
        _dbSet.Update(entity);
        Save(isCommit);
    }
    public async Task UpdateAsync(T entity, bool isCommit = true, CancellationToken cancellationToken = new CancellationToken())
    {
        _dbSet.Update(entity);
        await SaveChangesAsync(isCommit, cancellationToken);
    }

    public async Task<int> SaveChangesAsync(bool isCommit = true, CancellationToken cancellationToken = new CancellationToken()) => await _context.SaveChangesAsync(isCommit, cancellationToken);

    public int Save(bool isCommit = true) => _context.SaveChanges(isCommit);

    public T Find(Expression<Func<T, bool>> match) => Table.SingleOrDefault(match);

    public ICollection<T> FindAll(Expression<Func<T, bool>> match) => Table.Where(match).ToList();

    /// <summary>
    /// Don't use multiple async/await operation on same context. SEE link
    /// https://aka.ms/efcore-docs-threading
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default)
    {
        var result = await Table.Where(match).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default)
    {
        var result = await Table.FirstOrDefaultAsync(match, cancellationToken);
        return result;
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => Table.Where(predicate);

    public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await Table.Where(predicate).ToListAsync(cancellationToken);
        return result;
    }

    public T Get(object id) => _dbSet.Find(id);

    public IQueryable<T> GetAll() => Table;

    public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await Table.ToListAsync(cancellationToken);
        return result;
    }

    public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        var result = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        return result;
    }

    public IQueryable<T> IncludeMany(params Expression<Func<T, object>>[] includes)
    {
        if (includes != null)
        {
            _dbSet = includes.Aggregate(_dbSet, (current, include) => (DbSet<T>)current.Include(include));
        }
        return _dbSet;
    }

    public IQueryable<T> IncludeMany(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        return query.Where(predicate);
    }



    public void UpdateSpecialProperties(T entity, bool isCommit = true, params Expression<Func<T, object>>[] properties)
    {
        var entry = _context.Entry(entity);

        entry.State = EntityState.Unchanged;

        foreach (var prop in properties)
        {
            entry.Property(prop).IsModified = true;
        }

        Save(isCommit);
    }

    public void UpdateExceptedProperties(T entity, bool isCommit = false, params Expression<Func<T, object>>[] properties)
    {
        var entry = _context.Entry(entity);

        entry.State = EntityState.Modified;

        foreach (var prop in properties)
        {
            entry.Property(prop).IsModified = false;
        }

        Save(isCommit);
    }
}

