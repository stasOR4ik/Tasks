using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using MusicSite.Models;
using MusicSite.Models.Repositories;
using Newtonsoft.Json;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMusicDbContextRepository _dbRepository;
        //private readonly MusicRepository<Song> _songRepository;
        //private readonly MusicRepository<Singer> _singerRepository;
        //private readonly MusicRepository<Album> _albumRepository;
        private StorageProcedure _procedure;

        //public HomeController()
        //{
        //    _procedure = new StorageProcedure();
        //}

        public HomeController(MusicDbContextRepository dbRepository, StorageProcedure procedure/*, MusicRepository<Song> songRepository,
            MusicRepository<Singer> singerRepository, MusicRepository<Album> albumRepository*/ )
        {
            //_singerRepository = singerRepository;
            //_songRepository = songRepository;
            //_albumRepository = albumRepository;

            _dbRepository = dbRepository;
            _procedure = procedure;
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
            return JsonConvert.SerializeObject(_procedure.TableAlbumsTakingBySingerId(singerId));
        }

        public string ConvertToJsonSongsTakingBySingerId(int singerId)
        {
            return JsonConvert.SerializeObject(RenameSongsTextsIfNull(_procedure.TableSongsTakingBySingerId(singerId)));
        }

        public string ConvertToJsonSongsTakingByAlbumId(int albumId)
        {
            return JsonConvert.SerializeObject(RenameSongsTextsIfNull(_procedure.TableSongsTakingByAlbumId(albumId)));
        }
    }
}
