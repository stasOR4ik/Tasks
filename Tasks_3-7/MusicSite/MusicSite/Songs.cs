using System;
using System.Collections.Generic;

namespace MusicSite
{
    public partial class Songs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int SingerId { get; set; }
        public int AlbumId { get; set; }

        public Albums Album { get; set; }
        public Singers Singer { get; set; }
    }
}
