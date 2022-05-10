using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz_Xuxa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        async void onResponderClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(
               "Responda:", "Cancel", null,
               "Sucesso",
               "Redirecionamento",
               "Erro do Cliente",
               "Erro do Servidor");

            if (action != "Sucesso")
            {
                await DisplayAlert("😢", "Que Pena, Voce Errou", "Cancelar");
            }
            else
            {
                await DisplayAlert("🎉", "Parabens!", "Ok");
                App.Pontos++;
            }
            await Navigation.PushAsync(new Page4());
        }

        async void onDesistirClicked(object sender, EventArgs e)
        {
            await DisplayAlert("😢", "Que Pena, Tente Novamente Depois!", "Cancelar");
            await Navigation.PushAsync(new MainPage());
        }
    }
}