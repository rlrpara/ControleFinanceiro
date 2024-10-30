using MinhasFinancas.App.Views;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data.Repositories;
using MinhasFinancas.Service.Interface;
using MinhasFinancas.Service.Service;

namespace MinhasFinancas.App;

public static class RegisterDependencies
{
    public static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<ITransacaoService, TransacaoService>();
        mauiAppBuilder.Services.AddTransient<ITransacaoRepository, TransacaoRepository>();
        mauiAppBuilder.Services.AddTransient<IBaseRepository, BaseRepository>();
        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<TransacaoAdd>();
        mauiAppBuilder.Services.AddTransient<TransacaoEdit>();
        mauiAppBuilder.Services.AddTransient<TransacaoLista>();

        return mauiAppBuilder;
    }
}
