using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Persona
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public Persona(int id, String nombre, String telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
