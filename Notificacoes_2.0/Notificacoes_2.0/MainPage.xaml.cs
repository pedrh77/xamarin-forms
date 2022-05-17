using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Notificacoes_2._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        double dvolume = 1.0, dtom = 0.75;
        private async void OnBtn_Falar(object sender, EventArgs e)
        {
            var settings = new SpeechOptions()
            {
                Volume = Convert.ToSingle(dvolume),
                Pitch = Convert.ToSingle(dtom)
            };

            if (Falar.Text == null || string.IsNullOrWhiteSpace(Falar.Text) || string.IsNullOrEmpty(Falar.Text))
                await TextToSpeech.SpeakAsync("Olá eu sou o App Falador", settings);
            else await TextToSpeech.SpeakAsync(Falar.Text, settings);
        }

        private void onVolumeChange(object sender, ValueChangedEventArgs e)
        {
            dvolume = e.NewValue;
            lblvolume.Text = $"Volume da Voz: {e.NewValue}";
        }

        private void onTomChange(object sender, ValueChangedEventArgs e)
        {
            dtom = Convert.ToDouble(e.NewValue);
            lblTom.Text = $"Tom de : {e.NewValue}";
        }


    }
}
