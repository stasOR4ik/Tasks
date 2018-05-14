using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite.Models.Repositories
{
    public class MusicDbContextRepository
    {
        MusicDBContext context;
        public MusicRepository<Song> Songs { get; set; }
        public MusicRepository<Singer> Singers { get; set; }
        public MusicRepository<Album> Albums { get; set; }

        public MusicDbContextRepository()
        {
            context = new MusicDBContext();
            Songs = new MusicRepository<Song>(context);
            Singers = new MusicRepository<Singer>(context);
            Albums = new MusicRepository<Album>(context);
        }
    }
}
