using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Ufo.BL;
using Ufo.Commander.ViewModel;
using Ufo.Commander.ViewModel.Basic;
using Ufo.Commander.Views;

namespace Ufo.Commander
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public App()
        {
            logger.Info("Start application");
            DispatcherUnhandledException += App_DispatscheUnhandledExceptions;
        }


        private void App_DispatscheUnhandledExceptions(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            logger.Fatal(e.Exception, "Unhandler exception thrown!");
            e.Handled = true;
        }
    }
}
