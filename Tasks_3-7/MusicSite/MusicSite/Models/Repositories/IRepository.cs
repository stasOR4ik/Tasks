﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicSite
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAllList();
        IEnumerable<T> GetAllBy(Expression<Func<T, bool>> predicate);
        T GetBy(Expression<Func<T, bool>> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(Expression<Func<T, bool>> predicate);
        void Save();
    }
}
