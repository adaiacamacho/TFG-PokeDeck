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

        //obtener cartas
        public static string GetCartas(int pagina)
        {
            return $"https://api.pokemontcg.io/v2/cards?page={pagina}&pageSize=250";
        }


        //https://api.pokemontcg.io/v2/cards?q=name:*charizard* AND types:darkness AND weaknesses.type:grass&page=2&pageSize=250


        //obtener cartas por nombre
        public static string GetCartasPorNombre(string nombre, int pagina)
        {
            return "https://api.pokemontcg.io/v2/cards?q=name:*"+nombre+ "*&page="+pagina+"pageSize=250";
        }

        //obtener cartas por tipo
        public static string GetCartasPorTipo(string tipo, int pagina)
        {
            return $"https://api.pokemontcg.io/v2/cards?page={pagina}&pageSize=250q=types:*" + tipo + "*";
        }

        //obtener cartas por tipo
        public static string GetCartasPorDebilidad(string debilidad, int pagina)
        {
            return $"https://api.pokemontcg.io/v2/cards?page={pagina}&pageSize=250q=types:*" + debilidad + "*";
        }

        //obtener cartas por rareza
        public static string GetCartasPorRareza(string rareza, int pagina)
        {
            return $"https://api.pokemontcg.io/v2/cards?page={pagina}&pageSize=250q=types:*" + rareza + "*";
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

        public static void ChangeLanguage(ChangeEventArgs e)
        {
            SelectedLanguage = e.Value.ToString();
        }
        public static string ImagenParse(byte[] imagenBytes)
        {
            var base64 = Convert.ToBase64String(imagenBytes);
            return $"data:image/png;base64,{base64}";
        }

    }

}
