using System;
using System.Collections.Generic;

namespace MusicSite
{
    public partial class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SingerId { get; set; }

        public Singer Singer { get; set; }
        public ICollection<Song> Songs { get; set; }

        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public Album(int id, string name, int singerId)
        {
            Id = id;
            Name = name;
            SingerId = singerId;
        }

    }
}
