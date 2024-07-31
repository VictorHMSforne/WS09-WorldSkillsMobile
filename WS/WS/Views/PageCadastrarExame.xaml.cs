using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Models;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrarExame : ContentPage
    {
        public PageCadastrarExame()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDias.Text) <= 0)
                {
                    DisplayAlert("Dia inválido", "Data inserida inválida", "Ok");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtNomeExame.Text) == true || string.IsNullOrEmpty(txtDias.Text) == true)
                    {
                        DisplayAlert("Campos Vazios", "Preencha os Campos!", "Ok");
                    }
                    else
                    {
                        ServiceDbExame dbExame = new ServiceDbExame(App.DbPath);
                        Exame exame = new Exame();
                        exame.Nome_Exame = txtNomeExame.Text;
                        exame.Dias = Convert.ToInt32(txtDias.Text);
                        dbExame.CadastrarExame(exame);
                        DisplayAlert("Cadastro de Exame", "Realizado com Sucesso!", "Ok");
                        Navigation.PopAsync();
                    }
                    
                }
                
            }
            catch (Exception er)
            {
                DisplayAlert("Erro", er.Message, "Ok");
            }
            
        }
    }
}