using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Ufo.BL;
using Ufo.Domain;

namespace Ufo.Service
{
    /// <summary>
    /// Summary description for UfoService
    /// </summary>
    [WebService(Namespace = "http://service.ufo/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UfoService : WebService
    {
        private IViewer viewBL = BLFactory.GetViewer();

        [WebMethod]
        public List<Artist> GetAllArtists()
        {
            return new List<Artist>(viewBL.GetAllArtists());
        }

        [WebMethod]
        public Artist GetArtistById(int id)
        {
            return viewBL.GetArtistById(id);
        }

        [WebMethod]
        public List<Artist> GetAllArtistsByCategory(Category category)
        {
            return new List<Artist>(viewBL.GetAllArtistsByCategory(category));
        }

        [WebMethod]
        public List<Artist> GetAllArtistsByCountry(string country)
        {
            return new List<Artist>(viewBL.GetAllArtistsByCountry(country));
        }

        [WebMethod]
        public List<Category> GetAllCategories()
        {
            return new List<Category>(viewBL.GetAllCategories());
        }

        [WebMethod]
        public List<Performance> GetAllPerformances()
        {
            return new List<Performance>(viewBL.GetAllPerformances());
        }

        [WebMethod]
        public List<Performance> GetPerformancesByDay(string date)
        {
            DateTime day;
            
            if (DateTime.TryParse(date, out day))
            {
                return new List<Performance>(viewBL.GetPerformanceByDay(day));
            }

            return new List<Performance>();
        }

        [WebMethod]
        public List<Venue> GetAllVenues()
        {
            return new List<Venue>(viewBL.GetAllVenues());
        }

        [WebMethod]
        public List<Performance> GetPerformanceByArtist(Artist artist)
        {
            return new List<Performance>(viewBL.GetPerformanceByArtist(artist));
        }

        [WebMethod]
        public List<Performance> GetPerformanceByVenueAndDate(Venue venue, string date)
        {
            DateTime day;

            if (DateTime.TryParse(date, out day))
            {
                return new List<Performance>(viewBL.GetPerformanceByVenueAndDate(venue, day));
            }

            return new List<Performance>();
        }

        [WebMethod]
        public List<Performance> GetPerformanceByVenue(Venue venue)
        {
            return new List<Performance>(viewBL.GetPerformanceByVenue(venue));
        }

        [WebMethod]
        public bool UpdatePerformance(Performance p)
        {
            return viewBL.UpdatePerformance(p);
        }

        [WebMethod]
        public bool IsPerformanceValid(Performance p)
        {
            return viewBL.IsPerformanceValid(p);
        }

        [WebMethod]
        public Performance GetPerformanceById(int id)
        {
            return viewBL.GetPerformanceById(id);
        }

        [WebMethod]
        public List<Venue> GetVenuesByLocation(string location)
        {
            return new List<Venue>(viewBL.GetVenuesByLocation(location));
        }


        [WebMethod]
        public bool Login(string username, string password)
        {
            return viewBL.Login(username, password);
        }

        [WebMethod]
        public string ComputeHash(string input)
        {
            return viewBL.HashPassword(input);
        }
    }
}
