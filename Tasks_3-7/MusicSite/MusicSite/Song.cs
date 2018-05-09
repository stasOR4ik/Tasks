using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite
{
    public class Song
    {
        public Song(int id, string name, string text, int singerId, int albumId)
        {
            Id = id;
            Name = name;
            Text = text;
            SingerId = singerId;
            AlbumId = albumId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int SingerId { get; set; }
        public int AlbumId { get; set; }

        public static string ConvertTextIfNull(string text)
        {
            if (text == null)
                return "-";
            return text;
        }
    }
}
