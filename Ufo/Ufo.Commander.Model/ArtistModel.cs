using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.Model
{
    public class ArtistModel
    {
        private Artist artist;

        #region ctor
        public ArtistModel()
        {
            artist = new Artist();
        }

        public ArtistModel(Artist artist)
        {
            this.artist = artist;
        }
        #endregion

        public Artist GetInstance()
        {
            return artist;
        }

        public string Name
        {
            get { return artist.Name; }
            set { artist.Name = value; }
        }

        public string Country
        {
            get { return artist.Country; }
            set { artist.Country = value; }
        }

        public string Email
        {
            get { return artist.Email; }
            set { artist.Email = value; }
        }

        public string Description
        {
            get { return artist.Description; }
            set { artist.Description = value; }
        }

        public string Homepage
        {
            get { return artist.Homepage; }
            set { artist.Homepage = value; }
        }

        public string Picture
        {
            get { return artist.PictureUrl; }
            set { artist.PictureUrl = value; }
        }

        public string Video
        {
            get { return artist.VideoUrl; }
            set { artist.VideoUrl = value; }
        }

        public CategoryModel Category
        {
            get { return new CategoryModel(artist.Category); }
            set { artist.Category = value.GetInstance(); }
        }
    }
}
