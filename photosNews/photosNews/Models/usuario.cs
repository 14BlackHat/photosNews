using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace photosStarWars.Models
{
    public class usuario
    {
        [PrimaryKey, AutoIncrement]
        public int idUsuario { get; set; }
        [MaxLength(50)]

        [Unique]
        public string nombre { get; set; }
        [MaxLength(100)]

        public string email { get; set; }
        [MaxLength(50)]
        public string password { get; set; }
    }
}
