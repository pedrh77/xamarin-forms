using SQLite;

namespace SqlLite.Models
{
    public class Contato
    {
        [PrimaryKey, AutoIncrement]
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
    }
}
