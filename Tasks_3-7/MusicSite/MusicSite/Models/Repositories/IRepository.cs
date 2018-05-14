using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite
{
    interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAllList();
        IEnumerable<T> GetAllById(int id);
        T GetObject(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
