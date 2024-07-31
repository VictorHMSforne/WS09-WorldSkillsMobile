using System;
//adicionado WS.Views para poder usar a View PagePrincipal
using WS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS
{
    public partial class App : Application
    {
        //strings para auxiliar na localização do BD
        public static string DbPath;
        public static string DbName;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PagePrincipal());
        }
        //Após o App ser executado pela segunda vez, ele irá começar a utilizar esse método com parâmetros do BD
        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            App.DbPath = dbPath;
            App.DbName = dbName;
            MainPage = new NavigationPage(new PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
