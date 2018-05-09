using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicSite.Models;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //StorageProcedure procedure = new StorageProcedure();
            //SqlDataReader reader = procedure.TableSongsTakingBySingerId(3);
            //if (reader.HasRows)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            //    while (reader.Read())
            //    {
            //        int id = reader.GetInt32(0);
            //        string name = reader.GetString(1);
            //    }
            //}
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
    }
}
