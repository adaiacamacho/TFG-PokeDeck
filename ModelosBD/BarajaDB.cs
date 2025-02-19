using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.ModelosBD
{
    public class BarajaDB
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public DateOnly FechaCreacion { get; set; }

        public string Nombre { get; set; }

        public object[] Carta { get; set; }

        public object IdUserNavigation { get; set; }
    }
}
