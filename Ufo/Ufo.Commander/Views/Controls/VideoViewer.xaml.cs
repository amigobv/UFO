using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

// ReSharper disable once CheckNamespace
namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for VideoViewer.xaml
    /// </summary>                     
    public partial class VideoViewer
    {
        #region fields
        private Point _startPoint;
        private Point _endPoint;
        #endregion

        public VideoViewer()
        {
            InitializeComponent();

            var timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += VideoTick;
            timer.Start();
        }

        private void VideoTick(object sender, EventArgs e)
        {
            if (Player == null)
                return;

            if (Player.Source == null)
                return;

            if (Player.NaturalDuration.HasTimeSpan)
            {
                SliProgress.Value = Player.Position.TotalSeconds;
            }
        }

        #region events
        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Player.NaturalDuration.HasTimeSpan)
            {
                LblProgressEnd.Content =
                    TimeSpan.FromSeconds(Player.NaturalDuration.TimeSpan.TotalSeconds).ToString(@"hh\:mm\:ss");
                SliProgress.Minimum = 0;
                SliProgress.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
            }

            Player.LoadedBehavior = MediaState.Manual;
            SliVolume.Value = Player.Volume*100;
            Player.Pause();
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (Player != null) && (Player.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Player.Source.ToString()))
            {
                Player.Play();
            }
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (Player != null) && (Player.Source != null);
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Player.Source.ToString()))
            {
                Player.Pause();
            }
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (Player != null) && (Player.Source != null); 
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Player.Source.ToString()))
            {
                Player.Stop();
            }
        }

        private void SliProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LblProgressStatus.Content = TimeSpan.FromSeconds(SliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void SliProgress_OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (!string.IsNullOrEmpty(Player.Source.ToString()))
            {
                Player.Pause();
                var ratio = e.DeltaManipulation.Translation.X / SliProgress.ActualWidth;
                var deltaSeconds = Player.NaturalDuration.TimeSpan.TotalSeconds * ratio;
                Player.Position += TimeSpan.FromSeconds(deltaSeconds);
                LblProgressStatus.Content = Player.Position.ToString(@"hh\:mm\:ss");
                Player.Play();
            }

            e.Handled = true;
        }

        private void SliProgress_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(Player.Source.ToString()))
            {
                Player.Pause();
                _startPoint = e.GetPosition(this);
            }
            e.Handled = true;
        }

        private void SliProgress_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(Player.Source.ToString()))
            {
                _endPoint = e.GetPosition(this);
                var delta = _endPoint.X - _startPoint.X;
                var ratio = delta / SliProgress.ActualWidth;
                var deltaSeconds = Player.NaturalDuration.TimeSpan.TotalSeconds * ratio;
                Player.Position += TimeSpan.FromSeconds(deltaSeconds);
                LblProgressStatus.Content = Player.Position.ToString(@"hh\:mm\:ss");
                Player.Play();
            }

            e.Handled = true;
        }
        #endregion

        private void SliVolume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Volume = e.NewValue/100.0;
        }
    }
}
