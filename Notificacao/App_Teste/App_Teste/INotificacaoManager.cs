using System;

namespace App_Teste
{
    public interface INotificacaoManager
    {
        event EventHandler NotificacaoRecebida;
        void Initialize();

        int OrdemNotificacao(string title, string message);
        void ReceberNoficacao(string title, string message);
    }
}
