using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DomainClass
{
    class Artist : IDomain
    {
        #region Properties
        // TODO change Picture and Avertiesment to a correct type
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }
        public string Description { get; set; }
        public Object Picture { get; set; }
        public Object Advertisment { get; set; }
        #endregion

        public Artist(int id, string name, string country, string email, string homepage, 
                      string description, Object picture, Object advertisment)
        {
            Id = id;
            Name = name;
            Country = country;
            Email = email;
            Homepage = homepage;
            Description = description;
            Advertisment = advertisment;
            Picture = picture;
        }

        public override string ToString()
        {
            return "Artist: " + Name + " (" + Country + ") : " + Email + ", " + Homepage;
        }
    }
}
