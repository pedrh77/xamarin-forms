using SqlLite.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SqlLite
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //Ler todos os Registros
            var contatoList = await App.SQLiteDb.LerTodosContatosAsync();
            if (contatoList != null)
            {
                lstDados.ItemsSource = contatoList;
                HabilitarBotoes(true);
                lstDados.Focus();
            }
        }



        private void BtnNovo_Clicked(object sender, EventArgs e)
        {
            txtContatoId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCelular.Text = string.Empty;
            HabilitarBotoes(false);
            txtNome.Focus();
        }
        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            HabilitarBotoes(false);
            txtNome.Focus();
        }
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                Contato contato = new Contato()
                {
                    ContatoId = txtContatoId.Text == "" ? 0 :
               Convert.ToInt32(txtContatoId.Text),
                    Nome = txtNome.Text.ToUpper(),
                    Celular = txtCelular.Text
                };
                //Gravar Registro
                await App.SQLiteDb.GravarItemAsync(contato);
                txtContatoId.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtCelular.Text = string.Empty;
                await DisplayAlert("Atenção", "Registro atualizado", "OK");
                //Ler todos os Registros
                var contatoList = await App.SQLiteDb.LerTodosContatosAsync();
                if (contatoList != null)
                {
                    lstDados.ItemsSource = contatoList;
                    HabilitarBotoes(true);
                    lstDados.Focus();
                }
            }
            else await DisplayAlert("Atenção", "Campo Nome obrigatório!", "OK");

        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContatoId.Text))
            {
                var resposta = await DisplayAlert("Atenção",
                string.Format("Deseja Excluir {0}?", txtNome.Text), "Sim", "Não");
                if (resposta)
                {
                    //Ler um registro
                    var contato = await
                    App.SQLiteDb.LerContatoByIdAsync(Convert.ToInt32(txtContatoId.Text));
                    if (contato != null)
                    {
                        //Excluir Retgistro
                        await App.SQLiteDb.ExcluirItemAsync(contato);
                        txtContatoId.Text = string.Empty;
                        txtNome.Text = string.Empty;
                        txtCelular.Text = string.Empty;
                        await DisplayAlert("Atenção", "Registro excluído com sucesso", "OK");
                        //Ler todos os Registros
                        var contatoList = await App.SQLiteDb.LerTodosContatosAsync();
                        if (contatoList != null)
                        {
                            lstDados.ItemsSource = contatoList;
                            HabilitarBotoes(true);
                            lstDados.Focus();
                        }
                    }
                }
            }
        }
        private void lstDados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var contato = (Contato)e.SelectedItem;
                txtContatoId.Text = contato.ContatoId.ToString();
                txtNome.Text = contato.Nome;
                txtCelular.Text = contato.Celular;
                HabilitarBotoes(true);
                //((ListView)sender).SelectedItem = null; //desmarcar a linha selecionada
            }
        }
        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            HabilitarBotoes(true);
            lstDados.Focus();
        }
        private void HabilitarBotoes(bool status)
        {
            protegerDados(!status);
            btnNovo.IsEnabled = status;
            btnEditar.IsEnabled = status;
            btnDelete.IsEnabled = status;
            btnUpdate.IsEnabled = !status;
            btnCancelar.IsEnabled = !status;
        }
        private void protegerDados(bool status)
        {
            //inserir aqui todos os textBoxes, exceto ID
            txtNome.IsEnabled = status;
            txtCelular.IsEnabled = status;
        }
        private async void OnPesquisar(object sender, EventArgs e)
        {
            //Ler Registros filtrados
            var contatoList = await App.SQLiteDb.LerContatoFiltroAsync(txtPesquisar.Text.ToUpper());
            if (contatoList != null)
            {
                lstDados.ItemsSource = contatoList;
                HabilitarBotoes(true);
            }
        }
    }
}