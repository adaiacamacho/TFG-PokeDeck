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
        //https://api.pokemontcg.io/v2/cards?q=name:** AND types:** AND weaknesses.type:** AND cardmarket.prices.trendPrice:[minimo TO maximo]&page=pagina&pageSize=250

        public static string GetCartas(string nombre, string tipo, string debilidad, string rareza, float minimo, float maximo, int pagina)
        {
            string precioMax = "*";

            if (tipo == "-1")
            {
                tipo = "";
            }

            if (debilidad == "-1")
            {
                debilidad = "";
            }

            if (rareza == "-1")
            {
                rareza = "";
            }

            if (maximo != 0)
            {
                precioMax = maximo.ToString();
            }
                return $"https://api.pokemontcg.io/v2/cards?q=name:*{nombre}* AND types:*{tipo}* AND weaknesses.type:*{debilidad}* AND rarity:*{rareza}* AND cardmarket.prices.trendPrice:[{minimo} TO {precioMax}]&page={pagina}&pageSize=250";
        }

        //obtener los tipos y debilidades (es la misma lista)
        public static string GetTipos()
        {
            return "https://api.pokemontcg.io/v2/types";
        }

        //obtener las rareza
        public static string GetRarezas()
        {
            return "https://api.pokemontcg.io/v2/rarities";
        }

        public static string GetCarta(string id)
        {
            return "https://api.pokemontcg.io/v2/cards/"+id;
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
