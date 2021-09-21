
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public class DisposableRepository<TEntity, TContext> : IDisposable
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        private TContext db;

        private bool selfContext = false;

        private DbSet<TEntity> _objectSet;

        public DisposableRepository()
        {
            db = new TContext();

            _objectSet = db.Set<TEntity>();

            selfContext = true;
        }

        public DisposableRepository(TContext dbContext)
        {
            db = dbContext;
            _objectSet = db.Set<TEntity>();
        }

        public List<TEntity> List()
        {
            return _objectSet.ToList();
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> where)
        {
            return _objectSet.Where(where);
        }

        public int Insert(TEntity obj)
        {
            _objectSet.Add(obj);

            return db.SaveChanges();
        }

        public int Update(TEntity obj)
        {
            var updatedEntity = db.Entry(obj);
            updatedEntity.State = EntityState.Modified;
            return db.SaveChanges();
        }

        public TEntity Delete(TEntity obj)
        {
            return _objectSet.Remove(obj);
        }
        public int Save()
        {
            return db.SaveChanges();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return _objectSet.SingleOrDefault(where);
        }

        public void Dispose()
        {
            if (selfContext)
                db.Dispose();
        }
    }
}
