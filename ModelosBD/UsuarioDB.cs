using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PokeDeck.ModelosBD
{

    public class UsuarioDB
    {
        public int id { get; set; }
        public string usuario1 { get; set; }
        public string contrasena { get; set; }
        public int idIdioma { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public int? idImagen { get; set; }
        public object[]? barajas { get; set; }
        public object[]? favoritos { get; set; }
        public object? idIdiomaNavigation { get; set; }
        public object? idImagenNavigation { get; set; }
    }

}
