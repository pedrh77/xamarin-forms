using System;
using Xamarin.Forms;

namespace App_Teste
{
    public partial class MainPage : ContentPage
    {
        INotificacaoManager notificacaoManager;
        int notificacaoNumber = 0;
        public MainPage()
        {
            InitializeComponent();
            notificacaoManager = DependencyService.Get<INotificacaoManager>();
            notificacaoManager.NotificacaoRecebida += (sender, eventArgs) =>
            {
                var evtData = (NofificacaoEventArg)eventArgs;
                MostrarNoficacao(evtData.Title, evtData.Message);
            };
        }

        void MostrarNoficacao(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notificação Recebida: \nTitulo: {title}\nMensagem:{message}"
                };
                stackLayout.Children.Add(msg);
            });
        }

        private void onClickNotificacaoBtn(object sender, EventArgs e)
        {
            notificacaoNumber++;
            string title = $"Notificação do Pedro { notificacaoNumber}";
            string message = $"{DateTime.Now}";
            notificacaoManager.OrdemNotificacao(title, message);

        }
    }
}
