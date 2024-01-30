using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ejercicio_1._3.Models
{
    [SQLite.Table("Personas")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Nombres { get; set; }

        [MaxLength(100)]
        public string? Apellidos { get; set; }

        public int Edad { get; set; }

        [Unique]
        public string? Correo { get; set; }
        public string? Direccion {  get; set; }
    }
}
