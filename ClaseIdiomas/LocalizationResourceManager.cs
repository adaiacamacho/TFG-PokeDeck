using System.Globalization;
using System.Resources;
using Microsoft.Maui.Platform;

namespace PokeDeck.ClaseIdiomas
{
    public class LocalizationResourceManager
    {
        private readonly ResourceManager resourceManager;

        public event Action? OnLanguageChanged;
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
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            OnLanguageChanged?.Invoke();
        }
    }

}
