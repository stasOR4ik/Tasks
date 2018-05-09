using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicSite.Models;
using Newtonsoft.Json;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ConvertToJsonTableSongsTakingBySingerId(3);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string ConvertToJsonTableAlbumsTakingBySingerId(int singerId)
        {
            StorageProcedure procedure = new StorageProcedure();
            SqlDataReader reader = procedure.TableAlbumsTakingBySingerId(singerId);
            DataTable dataTable = new DataTable();
            List<Album> albums = new List<Album>();
            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                while (reader.Read())
                {
                    albums.Add(new Album(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
            }
            string json = JsonConvert.SerializeObject(albums);
            return json;
        }

        public string SafeGetString(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
                return reader.GetString(index);
            return string.Empty;
        }

        public string ConvertToJsonTableSongsTakingBySingerId(int singerId)
        {
            StorageProcedure procedure = new StorageProcedure();
            SqlDataReader reader = procedure.TableSongsTakingBySingerId(singerId);
            DataTable dataTable = new DataTable();
            List<Song> songs = new List<Song>();
            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2),
                    reader.GetName(3), reader.GetName(4));
                while (reader.Read())
                {
                    songs.Add(new Song(reader.GetInt32(0), reader.GetString(1), SafeGetString(reader, 2),
                        reader.GetInt32(3), reader.GetInt32(4)));
                }
            }
            string json = JsonConvert.SerializeObject(songs);
            return json;
        }

        public string ConvertToJsonTableSongsTakingByAlbumId(int albumId)
        {
            StorageProcedure procedure = new StorageProcedure();
            SqlDataReader reader = procedure.TableSongsTakingByAlbumId(albumId);
            DataTable dataTable = new DataTable();
            List<Song> songs = new List<Song>();
            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2),
                    reader.GetName(3), reader.GetName(4));
                while (reader.Read())
                {
                    songs.Add(new Song(reader.GetInt32(0), reader.GetString(1), SafeGetString(reader, 2),
                        reader.GetInt32(3), reader.GetInt32(4)));
                }
            }
            string json = JsonConvert.SerializeObject(songs);
            return json;
        }
    }
}
