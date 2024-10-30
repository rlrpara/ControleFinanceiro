namespace ControleFinanceiro.CrossCutting.Util.ExtensionMethods;

public static class StreingExtension
{
    private static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<ITransacaoService, TransacaoService>();
        mauiAppBuilder.Services.AddTransient<ITransacaoRepository, TransacaoRepository>();
        mauiAppBuilder.Services.AddTransient<IBaseRepository, BaseRepository>();
        return mauiAppBuilder;
    }
    private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<TransacaoAdd>();
        mauiAppBuilder.Services.AddTransient<TransacaoEdit>();
        mauiAppBuilder.Services.AddTransient<TransacaoLista>();

        return mauiAppBuilder;
    }
}
