using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Localizacao
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnExibirMapa_Clicked(object sender, EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    await Map.OpenAsync(location);
                }
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Erro", "Recurso Localização não Suportado", "OK");

            }
            catch (PermissionException)
            {
                await DisplayAlert("Erro", "Sem Permissão para Localização", "Ok");
            }
            catch (Exception)
            {
                await DisplayAlert("Erro", "Recurso de Localização não executado", "Ok");
            }
        }

        private async void OnObterCoord_Clicked(object sender, EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    lblLat.Text = "Latitude: " + location.Latitude.ToString();
                    lblLong.Text = "Longitude: " + location.Longitude.ToString();
                    lblAlt.Text = "Altitude: " + location.Altitude.ToString();
                }
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Erro", "Recurso Localização não Suportado", "OK");
            }
            catch (PermissionException)
            {
                await DisplayAlert("Erro", "Sem Permissão para Localização", "Ok");
            }
            catch (Exception)
            {
                await DisplayAlert("Erro", "Recurso de Localização não executado", "Ok");
            }
        }

        private async void OnMostrarMapaEndereco_Clicked(object sender, EventArgs e)
        {
            try
            {
                var LocalEndereco = await Geocoding.GetLocationsAsync(txtEndereco.Text);

                var location = LocalEndereco?.FirstOrDefault();
                if (location != null)
                {
                    await Map.OpenAsync(location);
                }
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Erro", "Recurso Localização não suportado", "Ok");
            }
            catch (PermissionException)
            {
                await DisplayAlert("Erro", "Sem permissão para a Localização", "Ok");
            }
            catch (Exception)
            {
                await DisplayAlert("Erro", "Recurso de Localização não Executado", "Ok");
            }
        }

        private async void OnMostrarCoord_Clicked(object sender, EventArgs e)
        {
            try
            {
                var LocalEndereco = await Geocoding.GetLocationsAsync(txtEndereco.Text.ToString());
                var location = LocalEndereco?.FirstOrDefault();
                if (location != null)
                {

                    lblLat.Text = "Latitude: " + location.Latitude.ToString();
                    lblLong.Text = "Longitude: " + location.Longitude.ToString();
                    lblAlt.Text = "Altitude: " + location.Altitude.ToString();
                }
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Erro", "Recurso Localização não suportado", "Ok");
            }
            catch (PermissionException)
            {
                await DisplayAlert("Erro", "Sem permissão para a Localização", "Ok");
            }
            catch (Exception)
            {
                await DisplayAlert("Erro", "Recurso de Localização não Executado", "Ok");
            }
        }

    }
}
