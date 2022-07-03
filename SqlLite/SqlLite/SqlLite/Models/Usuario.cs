using SQLite;

namespace SqlLite.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }

    }
}
