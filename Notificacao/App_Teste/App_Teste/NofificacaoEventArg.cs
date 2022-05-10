using System;

namespace App_Teste
{
    public class NofificacaoEventArg : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
