using MovieOMdbAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieOMdbAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetData(string Search)
        {

            HttpWebRequest request = WebRequest.CreateHttp("http://www.omdbapi.com/?s=" + Search + "&apikey=459c139");
            //HttpWebRequest request = WebRequest.CreateHttp("http://www.omdbapi.com/?t=" + Search + "&apikey=459c139");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject MoviesJson = JObject.Parse(data);
            List<Movies> foundMovies = new List<Movies>();
            if (MoviesJson["Response"].ToString() == "True")
            {
                for (int i = 0; i < MoviesJson["Search"].Count(); i++)
                {
                    if (MoviesJson["Search"][i]["Type"].ToString() == "movie")
                    {
                        string title = MoviesJson["Search"][i]["Title"].ToString();
                        string year = MoviesJson["Search"][i]["Year"].ToString();
                        string poster = MoviesJson["Search"][i]["Poster"].ToString();
                        Movies m = new Movies(title, year, poster);
                        foundMovies.Add(m);
                    }
                }
                ViewBag.Results = foundMovies;
                return View(foundMovies);
            }

            return View();
        }
    }
}