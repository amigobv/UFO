using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ufo.Command.ViewModel;
using Ufo.Commander.ViewModel;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for ArtistEditView.xaml
    /// </summary>
    public partial class ArtistControl : UserControl
    {
        public ArtistViewModel ViewModel
        {
            get
            {
                return DataContext as ArtistViewModel;
            }
        }

        public ArtistControl()
        {
            InitializeComponent();
        }

        private void BrowsePicture_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel == null)
                return;

            Stream picture;
            var fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "C:\\";
            fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            fileDialog.FilterIndex = 3;


            if (fileDialog.ShowDialog() ?? false)
            {
                try
                {
                    if ((picture = fileDialog.OpenFile()) != null)
                    {
                        using (picture)
                        {
                            var folder = @"C:\Temp\Commander\Images\";
                            
                            if (!Directory.Exists(folder))
                                Directory.CreateDirectory(folder);

                            var url = folder + System.IO.Path.GetFileName(fileDialog.FileName);

                            using (var file = File.Create(url))
                            {
                                picture.CopyTo(file);

                            }

                            ViewModel.Picture = url;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BrowseVideo_Click(object sender, RoutedEventArgs e)
        {
            Stream video;
            var fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "C:\\";
            fileDialog.Filter = "AVI Files (*.avi)|*.avi|Mp4 Files (*.mp4)|*.mp4";
            fileDialog.FilterIndex = 2;


            if (fileDialog.ShowDialog() ?? false)
            {
                try
                {
                    if ((video = fileDialog.OpenFile()) != null)
                    {
                        using (video)
                        {
                            var folder = @"C:\Temp\Commander\Videos\";

                            if (!Directory.Exists(folder))
                                Directory.CreateDirectory(folder);

                            var url = folder + System.IO.Path.GetFileName(fileDialog.FileName);

                            using (var file = File.Create(url))
                            {
                                video.CopyTo(file);

                            }

                            ViewModel.Video = url;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
