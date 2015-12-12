﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Commander.Model;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class PerformanceViewModel : ViewModelBase
    {
        #region private members
        private TimeViewModel time;
        private IManager manager;
        private Performance performance;
        private ObservableCollection<Artist> artists;
        private ObservableCollection<Venue> venues;
        #endregion

        #region ctor
        public PerformanceViewModel(IManager manager)
        {
            this.manager = manager;
            this.time = new TimeViewModel();
            this.performance = new Performance();
            InitialiazeCollections();
        }

        public PerformanceViewModel(Performance performance, IManager manager)
        {
            this.manager = manager;
            this.performance = performance;
            this.time = new TimeViewModel(new TimeModel(performance.Start.Hour, performance.Start.Minute));
            InitialiazeCollections();
        }

        private void InitialiazeCollections()
        {
            this.artists = new ObservableCollection<Artist>();
            this.venues = new ObservableCollection<Venue>();
            LoadArtists();
            LoadVenues();
        }

        private void LoadVenues()
        {
            Venues.Clear();
            var venuesList = manager.GetAllVenues();

            foreach (var venue in venuesList)
                Venues.Add(venue);
        }

        private void LoadArtists()
        {
            Artists.Clear();
            //TODO: only the artists that are aloud should be returned
            var artistsList = manager.GetAllArtists();

            foreach (var artist in artistsList)
                Artists.Add(artist);
        }
        #endregion

        #region properties
        public TimeViewModel Time { get; set; }

        public ObservableCollection<Artist> Artists 
        { 
            get { return artists;}
            set
            {
                if (artists != value)
                {
                    artists = value;
                    RaisePropertyChangedEvent(nameof(Artists));
                }
            }
        }

        public Artist Artist
        {
            get { return performance.Artist; }
            set
            {
                if (performance.Artist != value)
                {
                    performance.Artist = value;
                    RaisePropertyChangedEvent(nameof(Artist));
                }
            }
        }

        public ObservableCollection<Venue> Venues
        {
            get { return venues; }
            set
            {
                if (venues != value)
                {
                    venues = value;
                    RaisePropertyChangedEvent(nameof(Venues));
                }
            }
        }

        public Venue Venue
        {
            get { return performance.Venue; }
            set
            {
                if (performance.Venue != value)
                {
                    performance.Venue = value;
                    RaisePropertyChangedEvent(nameof(Venue));
                }
            }
        }

        public string Date
        {
            get { return performance.Start.ToString("HH:mm"); }
            //set
            //{
            //    if (performance.Start.Date != value.Date)
            //    {
            //        performance.Start = new DateTime(value.Date.Year, value.Date.Month, value.Date.Day, Time.Hour, 0, 0);
            //        RaisePropertyChangedEvent(nameof(Date));
            //    }
            //}
        }
        #endregion


    }
}
