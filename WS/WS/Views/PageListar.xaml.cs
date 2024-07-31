using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            
            InitializeComponent();
            ServiceDbPaciente dbPaciente = new ServiceDbPaciente(App.DbPath);
            lsView.ItemsSource = dbPaciente.ListarPaciente();
        }

        private void btnFiltrar_Clicked(object sender, EventArgs e)
        {
            ServiceDbPaciente dbPaciente = new ServiceDbPaciente(App.DbPath);
            lsView.ItemsSource = dbPaciente.ListarPaciente().Where(f => f.Data_Entrega == DpckFiltro.Date);
        }
    }
}