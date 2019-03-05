using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieOMdbAPI.Models
{
    public class Movies
    {
        
        public string Title { get; set; }
        
        public int Year { get; set; }
        public string Poster { get; set; }
        
        public Movies()
        {

        }
        public Movies(string title, string year, string poster)
        {
            
            Title = title;
           
            Year = int.Parse(year);
           
            Poster = poster;
        }

    }
}