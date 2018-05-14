using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicSite.Models;
using MusicSite.Models.Repositories;
using Newtonsoft.Json;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        MusicDbContextRepository dbRepository;

        public HomeController()
        {
            dbRepository = new MusicDbContextRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string SafeGetString(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
                return reader.GetString(index);
            return string.Empty;
        }

        public List<Album> AddAlbumsToList(SqlDataReader reader)
        {
            List<Album> albums = new List<Album>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    albums.Add(new Album(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
            }
            return albums;
        }

        public List<Song> AddSongsToList(SqlDataReader reader)
        {
            List<Song> songs = new List<Song>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    songs.Add(new Song(reader.GetInt32(0), reader.GetString(1), SafeGetString(reader, 2),
                        reader.GetInt32(3), reader.GetInt32(4)));
                }
            }
            return songs;
        }

        public string ConvertToJsonAlbumsTakingBySingerId(int singerId)
        {
            StorageProcedure procedure = new StorageProcedure();
            SqlDataReader reader = procedure.TableAlbumsTakingBySingerId(singerId);
            return JsonConvert.SerializeObject(AddAlbumsToList(reader));
        }

        public string ConvertToJsonSongsTakingBySingerId(int singerId)
        {
            StorageProcedure procedure = new StorageProcedure();
            SqlDataReader reader = procedure.TableSongsTakingBySingerId(singerId);
            return JsonConvert.SerializeObject(AddSongsToList(reader));
        }

        public string ConvertToJsonSongsTakingByAlbumId(int albumId)
        {
            StorageProcedure procedure = new StorageProcedure();
            SqlDataReader reader = procedure.TableSongsTakingByAlbumId(albumId);
            return JsonConvert.SerializeObject(AddSongsToList(reader));
        }
    }
}
