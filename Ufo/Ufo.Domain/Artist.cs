using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Domain
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
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }

        //private byte[] ReadMedia(string url)
        //{
        //    byte[] b;

        //    if (string.IsNullOrEmpty(url))
        //        return null;

        //    using (var file = File.OpenRead(url))
        //    {
        //        b = new byte[file.Length];
        //        while (file.Read(b, 0, b.Length) > 0) {;}

        //    }
        //    return b;
        //}
        #endregion

        #region ctor
        public Artist(int id, string name, string country, string email, string description,
                      string homepage, string picture, string video, Category category, bool deleted)
        {
            Id = id;
            Name = name;
            Country = country;
            Email = email;
            Homepage = homepage;
            Description = description;
            VideoUrl = video;
            PictureUrl = picture;
            Category = category;
            IsDeleted = deleted;
        }

        public Artist()
        {
            Id = 0;
            Name = string.Empty;
            Country = string.Empty;
            Email = string.Empty;
            Homepage = string.Empty;
            Description = string.Empty;
            VideoUrl = string.Empty;
            PictureUrl = string.Empty;
            Category = null;
            IsDeleted = false;
        }
        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as Artist;

            if (o != null)
            {
                return Id == o.Id &&
                       Name.Equals(o.Name) &&
                       Country.Equals(o.Country) &&
                       Email.Equals(o.Email);
            }

            return false;
        }

        public override string ToString()
        {
            return "Artist: " + Name + " (" + Country + ") : " + Email;
        }
    }
}
