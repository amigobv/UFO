using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Domain
{
    public class Artist
    {
        #region Properties
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }
        public string VideoUri { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        public Artist(int id, string name, string country, string email, string description,
                      string homepage, string picture, string video, Category category, bool deleted)
        {
            Id = id;
            Name = name;
            Country = country;
            Email = email;
            Homepage = homepage;
            Description = description;
            VideoUri = video;
            PictureUri = picture;
            Category = category;
            IsDeleted = deleted;
        }

        public override string ToString()
        {
            return "Artist: " + Name + " (" + Country + ") : " + Email;
        }
    }
}
