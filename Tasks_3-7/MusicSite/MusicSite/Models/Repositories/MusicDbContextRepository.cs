using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite.Models.Repositories
{
    public class MusicDbContextRepository :  IMusicDbContextRepository
    {
        public IRepository<Song> Songs { get; set; }
        public IRepository<Singer> Singers { get; set; }
        public IRepository<Album> Albums { get; set; }

        public MusicDbContextRepository(IRepository<Song> songs, IRepository<Singer> singers, IRepository<Album> albums)
        {
            Songs = songs;
            Singers = singers;
            Albums = albums;
        }


    }
}
