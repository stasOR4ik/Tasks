using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite.Models.Repositories
{
    public class SingerRepository : IRepository<Singer>
    {
        private MusicDBContext db;

        public SingerRepository()
        {
            db = new MusicDBContext();
        }

        public void Create(Singer item)
        {
            db.Singers.Add(item);
        }

        public void Delete(int id)
        {
            Singer singer = db.Singers.Find(id);
            if (singer != null)
                db.Singers.Remove(singer);
        }

        public IEnumerable<Singer> GetAllById(int id)
        {
            return db.Singers.Where(p => p.Id == id);
        }

        public IEnumerable<Singer> GetAllList()
        {
            return db.Singers;
        }

        public Singer GetObject(int id)
        {
            return db.Singers.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Singer item)
        {
            db.Singers.Update(item);
        }
    }
}
