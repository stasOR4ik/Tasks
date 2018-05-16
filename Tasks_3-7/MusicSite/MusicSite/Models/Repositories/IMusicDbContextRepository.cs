using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite.Models.Repositories
{
    interface IMusicDbContextRepository
    {
        IRepository<Song> Songs { get; set; }
        IRepository<Singer> Singers { get; set; }
        IRepository<Album> Albums { get; set; }
    }
}
