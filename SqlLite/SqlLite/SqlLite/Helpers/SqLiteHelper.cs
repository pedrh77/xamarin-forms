using SQLite;
using SqlLite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlLite.Helpers
{
    public class SqLiteHelper
    {
        SQLiteAsyncConnection db;
        public SqLiteHelper(string path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Contato>().Wait();
            db.CreateTableAsync<Usuario>().Wait();
        }

        /*-- CONTATOS --*/
        public Task<int> GravarItemAsync(Contato contato)
        {
            if (contato.ContatoId != 0) return db.UpdateAsync(contato);
            else return db.InsertAsync(contato);
        }

        public Task<int> ExcluirItemAsync(Contato contato)
        {
            return db.DeleteAsync(contato);
        }

        public Task<List<Contato>> LerTodosContatosAsync()
        {
            return db.Table<Contato>().ToListAsync();
            // oureturn db.QueryAsync<Contato>("SELECT * FROM Contato ORDER BY Nome");}//Ler um registro
        }
        //
        public Task<Contato> LerContatoByIdAsync(int contatoId)
        {
            return db.Table<Contato>().Where(i => i.ContatoId == contatoId).FirstOrDefaultAsync();
        }

        public Task<List<Contato>> LerContatoFiltroAsync(string svalor)
        {
            return db.Table<Contato>().Where(s => s.Nome.Contains(svalor)).ToListAsync();
        }
        /*-- USUARIOS --*/
        public Task<int> GravarItemAsync(Usuario contato)
        {
            if (contato.UsuarioId != 0) return db.UpdateAsync(contato);
            else return db.InsertAsync(contato);
        }

        public Task<int> ExcluirItemAsync(Usuario contato)
        {
            return db.DeleteAsync(contato);
        }

        public Task<List<Usuario>> LerTodosUsuariosAsync()
        {
            return db.Table<Usuario>().ToListAsync();
            // oureturn db.QueryAsync<Contato>("SELECT * FROM Contato ORDER BY Nome");}//Ler um registro
        }

        public Task<Usuario> LerUsuarioAsync(int usuarioid)
        {
            return db.Table<Usuario>().Where(i => i.UsuarioId == usuarioid).FirstOrDefaultAsync();
        }

        public Task<List<Usuario>> LerUsuarioFiltroAsync(string svalor)
        {
            return db.Table<Usuario>().Where(s => s.Nome.Contains(svalor)).ToListAsync();
        }
    }
}
