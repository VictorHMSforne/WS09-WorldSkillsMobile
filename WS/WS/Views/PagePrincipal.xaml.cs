﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrarPa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageCadastrar());
        }

        private void btnCadastrarExa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageCadastrarExame());
        }

        private void btnListar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageListar());
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}