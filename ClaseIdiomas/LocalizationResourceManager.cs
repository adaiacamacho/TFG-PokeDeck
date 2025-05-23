using System.Globalization;
using System.Resources;

namespace PokeDeck.ClaseIdiomas
{
    public class LocalizationResourceManager
    {
        private readonly ResourceManager resourceManager;

        public LocalizationResourceManager(ResourceManager resource)
        {
            resourceManager = resource;
        }

        public string this[string text]
        {
            get
            {
                return resourceManager.GetString(text, CultureInfo.CurrentUICulture)!;
            }
        }

        public void SetIdioma(string culture)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
        }
    }

}
