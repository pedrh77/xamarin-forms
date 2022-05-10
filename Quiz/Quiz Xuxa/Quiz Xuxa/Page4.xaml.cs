using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz_Xuxa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
           
            txtPontuacao.Text = $"Sua Pontuação é: {App.Pontos}";
            App.Pontos = 0;
        }
    }
}