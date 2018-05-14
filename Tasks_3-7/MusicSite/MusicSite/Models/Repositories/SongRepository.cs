using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite
{
    public class SongRepository : IRepository<Song>
    {
        private MusicDBContext db;

        public SongRepository()
        {
            db = new MusicDBContext();
        }

        public void Create(Song item)
        {
            db.Songs.Add(item);
        }

        public void Delete(int id)
        {
            Song song = db.Songs.Find(id);
            if (song != null)
                db.Songs.Remove(song);
        }

        public IEnumerable<Song> GetAllById(int id)
        {
            return db.Songs.Where(p => p.Id == id);
        }

        public IEnumerable<Song> GetAllList()
        {
            return db.Songs;
        }

        public Song GetObject(int id)
        {
            return db.Songs.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Song item)
        {
            db.Songs.Update(item);
        }
    }
}
