using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace MusicSite
{
    public class StorageProcedure
    {
        MusicDBContext db;

        public StorageProcedure()
        {
            db = new MusicDBContext();
        }

        public List<Album> TableAlbumsTakingBySingerId(int singerId)
        {

            return db.Albums.FromSql("AlbumsListBySingerId @singerId", new SqlParameter("@singerId", singerId)).ToList();
        }

        public List<Song> TableSongsTakingBySingerId(int singerId)
        {
            return db.Songs.FromSql("SongsListBySingerId @singerId", new SqlParameter("@singerId", singerId)).ToList();
        }

        public List<Song> TableSongsTakingByAlbumId(int albumId)
        {
           return db.Songs.FromSql("SongsListByAlbumId @albumId", new SqlParameter("@albumId", albumId)).ToList();
        }
    }
}
