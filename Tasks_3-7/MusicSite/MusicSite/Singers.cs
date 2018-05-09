using System;
using System.Collections.Generic;

namespace MusicSite
{
    public partial class Singers
    {
        public Singers()
        {
            Albums = new HashSet<Albums>();
            Songs = new HashSet<Songs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Albums> Albums { get; set; }
        public ICollection<Songs> Songs { get; set; }
    }
}
