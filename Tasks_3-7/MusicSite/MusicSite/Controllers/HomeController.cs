using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MusicSite.Models;
using MusicSite.Models.Repositories;
using Newtonsoft.Json;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        MusicDbContextRepository dbRepository;
        StorageProcedure procedure;

        public HomeController()
        {
            dbRepository = new MusicDbContextRepository();
            procedure = new StorageProcedure();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Song> RenameSongsTextsIfNull(List<Song> songs)
        {
            foreach(Song song in songs)
            {
                if (song.Text == null)
                {
                    song.Text = "";
                }
            }
            return songs;
        }

        public string ConvertToJsonAlbumsTakingBySingerId(int singerId)
        {
            return JsonConvert.SerializeObject(procedure.TableAlbumsTakingBySingerId(singerId));
        }

        public string ConvertToJsonSongsTakingBySingerId(int singerId)
        {
            return JsonConvert.SerializeObject(RenameSongsTextsIfNull(procedure.TableSongsTakingBySingerId(singerId)));
        }

        public string ConvertToJsonSongsTakingByAlbumId(int albumId)
        {
            return JsonConvert.SerializeObject(RenameSongsTextsIfNull(procedure.TableSongsTakingByAlbumId(albumId)));
        }
    }
}
