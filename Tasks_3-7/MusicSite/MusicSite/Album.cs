using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite
{
    public class Album
    {
        public Album() { }

        public Album(int id, string name, int singerId)
        {
            Id = id;
            Name = name;
            SingerId = singerId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SingerId { get; set; }
    }
}
