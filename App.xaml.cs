using Medii_maui.Data;
using System;
using System.IO;

namespace Medii_maui
{
    public partial class App : Application
    {
        static DeliveryDatabase database;
        public static DeliveryDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   DeliveryDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Deliveries.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }

}
