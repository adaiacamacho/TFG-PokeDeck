using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck
{
    internal class Metodos
    {
        public static bool perfil=false;
        public static string SelectedLanguage = "es";

        public static string GetCartas(int pagina)
        {
            return $"https://api.pokemontcg.io/v2/cards?page={pagina}&pageSize=250";
        }

        public static string GetCarta(string id)
        {
            return "https://api.pokemontcg.io/v2/cards/"+id;
        }

        public static string GetTipos()
        {
            return "https://api.pokemontcg.io/v2/types";
        }

        public static string GetRareza()
        {
            return "https://api.pokemontcg.io/v2/rarities";
        }

        public void ChangeLanguage(ChangeEventArgs e)
        {
            SelectedLanguage = e.Value.ToString();
        }

    }

}
