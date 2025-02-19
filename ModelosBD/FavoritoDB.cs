using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.ModelosBD
{
    public class FavoritoDB
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public object IdUserNavigation { get; set; } = null!;
    }
}
