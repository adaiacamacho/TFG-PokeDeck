using Microsoft.Extensions.Logging;
using PokeDeck.ClaseIdiomas;
using PokeDeck.Services;
using System.Resources;

namespace PokeDeck
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<BarajaService>();
            builder.Services.AddScoped<CartaService>();
            builder.Services.AddScoped<FavoritoService>();
            builder.Services.AddScoped<IdiomaService>();
            builder.Services.AddScoped<ImagenPerfilService>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped(sp => new HttpClient ());
            builder.Services.AddSingleton(new LocalizationResourceManager(Resources.Resource.ResourceManager));


            builder.Services.AddLocalization();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
