using System;
using System.Collections.Generic;

namespace MusicSite
{
    public partial class Albums
    {
        public Albums()
        {
            Songs = new HashSet<Songs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SingerId { get; set; }

        public Singers Singer { get; set; }
        public ICollection<Songs> Songs { get; set; }
    }
}
