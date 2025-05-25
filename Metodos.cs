
namespace PokeDeck
{
    internal class Metodos
    {
        public static bool perfil=false;
           
        //https://api.pokemontcg.io/v2/cards

        //obtener cartas     
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

        //obtener una carta en base a su id
        public static string GetCarta(string id)
        {
            return "https://api.pokemontcg.io/v2/cards/"+id;
        }

        //obtener cartas en base a una lista de IDs
        public static string GetCartasID(List<string> ListaIDs)
        {
            string query = string.Join(" OR ", ListaIDs.Select(id => $"id:{id}"));
            
            return $"https://api.pokemontcg.io/v2/cards?q={Uri.EscapeDataString(query)}";
        }
        public static string ImagenParse(byte[] imagenBytes)
        {
            var base64 = Convert.ToBase64String(imagenBytes);
            return $"data:image/png;base64,{base64}";
        }

    }

}
