using ControleFinanceiro.Domain.Enum;
using ControleFinanceiro.Infra.Database;
using Microsoft.Extensions.Logging;

namespace ControleFinanceiro.Mobile
{
    public static class MauiProgram
    {
        #region [Private Metods]
        private static void ObterConfiguracoesBanco()
        {
            var pasta = "";
            var tipo = ETipoProjeto.Desktop;
#if ANDROID
            pasta = AppContext.BaseDirectory.ToString();
            tipo = ETipoProjeto.Mobile;
#elif WINDOWS
            pasta = AppDomain.CurrentDomain.BaseDirectory.ToString();
#endif
            _ = new DatabaseConfiguration(pasta, tipo).GerenciarBanco();
        }
        #endregion
        public static MauiApp CreateMauiApp()
        {
            ObterConfiguracoesBanco();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterViews()
                .RegisterDatabaseAndRepositories();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
