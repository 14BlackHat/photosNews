using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using photosStarWars.Models;

namespace photosStarWars.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper (string dbPath)
        {
            db = new SQLiteAsyncConnection (dbPath);
            db.CreateTableAsync<usuario>().Wait();
        }

        public Task <int> guardarAlumno(usuario usuario)
        {
            if (usuario.idUsuario == 0)
            {
                return db.InsertAsync(usuario);
            }
            else
            {
                return null;
            }
        }

        public Task <List<usuario>> getUsuario()
        {
            return db.Table<usuario>().ToListAsync();
        }
        public Task<usuario> getUsuarioName(String nombre)
        {
            return db.Table<usuario>().Where(a => a.nombre == nombre).FirstOrDefaultAsync();
        }
    }
}
