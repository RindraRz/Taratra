using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Taratra.Models;

namespace Taratra
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using var db = new TaratraDbContext();
 
          
            db.Database.EnsureCreated();

        }

    }

}
