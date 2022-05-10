using BradescoApp.Pages;
using System;
using Xamarin.Forms;

namespace BradescoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void onLoginClick(object sender, EventArgs e)
        {

            var _cpf = "cnpj";
            var _senha = "123321";
            if (_cpf == Cpf.Text && _senha == Senha.Text) await Navigation.PushAsync(new Page1());
            await DisplayAlert("Falha ao Conectar", "Tente Logar Novamente", "OK");
        }

        private void onRegisterClick(object sender, EventArgs e)
        {

        }
    }
}
