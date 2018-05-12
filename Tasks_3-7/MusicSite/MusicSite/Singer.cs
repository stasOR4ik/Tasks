using System;
using System.Collections.Generic;

namespace MusicSite
{
    public partial class Singer
    {
        public Singer()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
