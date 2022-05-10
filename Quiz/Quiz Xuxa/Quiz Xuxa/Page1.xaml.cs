using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz_Xuxa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        async void onDesistirClicked(object sender, EventArgs e)
        {
            await DisplayAlert("😢", "Que Pena, Tente Novamente Depois!", "Cancelar");
            await Navigation.PopAsync();
        }

        async void onResponderClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Responda:", "Cancel", null, "Object Relational Mapper", "Object Randon Model", "Occurrence Relationship in the Model");
            if (action != "Object Relational Mapper") await DisplayAlert("😢", "Que Pena, Voce Errou", "Cancelar");
            else
            {
                App.Pontos++;
                await DisplayAlert("🎉", "Parabens!", "Ok");
            }
            await Navigation.PushAsync(new Page2());
        }
    }
}