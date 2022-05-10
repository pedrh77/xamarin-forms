using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppLanterna
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void onButtonOnnClicked(object sender, EventArgs e)
        {
            await Flashlight.TurnOnAsync();
        }

        private async void onButtonOffClicked(object sender, EventArgs e)
        {
            await Flashlight.TurnOffAsync();
        }


        private async void SwtToggledLanterna(object sender, ToggledEventArgs e)
        {
            if (e.Value == true) await Flashlight.TurnOnAsync();
            else await Flashlight.TurnOffAsync();

        }

        private void onButtonOnnClickedvibracao(object sender, EventArgs e)
        {
            Vibration.Vibrate();
        }

        private void onButtonOffClickedVibracao(object sender, EventArgs e)
        {
            Vibration.Cancel();
        }

        private void onSwtToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true) Vibration.Vibrate();

            else Vibration.Cancel();
        }
    }
}
