using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicSite.Models.Repositories
{
    public class MusicRepository<T> : IRepository<T>
        where T : class
    {
        private DbContext dbContext;
        private DbSet<T> db;

        public MusicRepository(DbContext context)
        {
            dbContext = context;
            db = context.Set<T>();
        }


        public void Create(T item)
        {
            db.Add(item);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            T item = db.Find(predicate);
            if (item != null)
                db.Remove(item);
        }

        public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> predicate)
        {
            return db.Where(predicate);
        }

        public IEnumerable<T> GetAllList()
        {
            return db;
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            return db.Find(predicate);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            db.Update(item);
        }
    }
}
