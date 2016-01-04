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
    [WebService(Namespace = "http://ufo2016.at/")]
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
        public List<Performance> GetPerformanceByVenue(Venue venue)
        {
            return new List<Performance>(viewBL.GetPerformanceByVenue(venue));
        }

        [WebMethod]
        public List<Venue> GetVenuesByLocation(string location)
        {
            return new List<Venue>(viewBL.GetVenuesByLocation(location));
        }


        public void SendEmail(string address, string subject, string content)
        {
            throw new NotImplementedException();
        }
    }
}
