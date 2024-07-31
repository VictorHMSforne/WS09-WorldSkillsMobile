using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WS.Models;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
            ServiceDbExame dbExame = new ServiceDbExame(App.DbPath);
            var exames = dbExame.ListarExame();
            pckExame.Items.Add("Escolha um Exame:");
            foreach (var exame in exames)
            {
                pckExame.Items.Add(exame.Nome_Exame);
            }
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            string dbPath = App.DbPath;
            SQLiteConnection conn = new SQLiteConnection(dbPath);
            ServiceDbPaciente dbPaciente = new ServiceDbPaciente(App.DbPath);
            Paciente paciente = new Paciente();

            try
            {
                string teste = pckExame.SelectedItem.ToString();
                string sqlExame = "SELECT Id FROM Exame WHERE Nome_Exame= '" + teste + "'";
                int IdExame = conn.ExecuteScalar<int>(sqlExame);
                
                if (string.IsNullOrEmpty(txtNome.Text) == true)
                {
                    DisplayAlert("Campos Vazios", "Preencha os Campos!", "Ok");
                }
                else
                {
                    paciente.Nome = txtNome.Text;
                    paciente.IdExame = IdExame;
                    paciente.Data_Exame = DpckRealizar.Date;
                    paciente.Data_Entrega = DpckExaPronto.Date;
                    dbPaciente.CadastrarPaciente(paciente);
                    DisplayAlert("Cadastro Realizado", "Paciente Cadastrado com Sucesso!", "Ok");
                    Navigation.PushAsync(new PageListar());
                }
            }
            catch (Exception er)
            {
                DisplayAlert("Erro", er.Message, "Ok");
            }
        }

        private void pckExame_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbPath = App.DbPath;
            SQLiteConnection conn = new SQLiteConnection(dbPath);
            string teste = pckExame.SelectedItem.ToString();
            string sqlDias = "SELECT Dias FROM Exame WHERE Nome_Exame= '" + teste + "'";
            double dias = conn.ExecuteScalar<double>(sqlDias);
            DpckExaPronto.Date = DateTime.Now.AddDays(dias);
        }
    }
}