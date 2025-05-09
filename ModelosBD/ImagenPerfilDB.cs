using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.ModelosBD
{

    public class ImagenPerfilDB
    {
        public int id { get; set; }
        public byte[]? Imagen { get; set; }
        public object[] usuarios { get; set; }
    }

}
