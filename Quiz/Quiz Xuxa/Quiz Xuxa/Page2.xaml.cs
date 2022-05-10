using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz_Xuxa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        async void onDesistirClicked(object sender, EventArgs e)
        {
            await DisplayAlert("😢", "Que Pena, Tente Novamente Depois!", "Cancelar");
            await Navigation.PushAsync(new MainPage());
        }

        async void onResponderClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(
                "Responda:", "Cancel", null,
                "Alterar, Busca, Criar e Deletar ",
                "Orientação, Mudança, Segurança e Desistencia",
                "Computaçao, Visao, Ressonancia, Moldagem",
                "Abstração, Encapsulamento, Herança, Polimorfismo");

            if (action != "Abstração, Encapsulamento, Herança, Polimorfismo")
            {

                await DisplayAlert("😢", "Que Pena, Voce Errou", "Cancelar");
            }
            else
            {
                App.Pontos++;
                await DisplayAlert("🎉", "Parabens!", "Ok");
            }
            await Navigation.PushAsync(new Page3());
        }
    }
}