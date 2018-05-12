using System;
using System.Collections.Generic;

namespace MusicSite
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int SingerId { get; set; }
        public int AlbumId { get; set; }

        public Album Album { get; set; }
        public Singer Singer { get; set; }

        public Song() { }

        public Song(int id, string name, string text, int singerId, int albumId)
        {
            Id = id;
            Name = name;
            Text = text;
            SingerId = singerId;
            AlbumId = albumId;
        }
    }
}
