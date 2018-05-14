using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite.Models.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private MusicDBContext db;

        public AlbumRepository()
        {
            db = new MusicDBContext();
        }

        public void Create(Album item)
        {
            db.Albums.Add(item);
        }

        public void Delete(int id)
        {
            Album album = db.Albums.Find(id);
            if (album != null)
                db.Albums.Remove(album);
        }

        public IEnumerable<Album> GetAllById(int id)
        {
            return db.Albums.Where(p => p.Id == id);
        }

        public IEnumerable<Album> GetAllList()
        {
            return db.Albums;
        }

        public Album GetObject(int id)
        {
            return db.Albums.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Album item)
        {
            db.Albums.Update(item);
        }
    }
}
