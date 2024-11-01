using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Repositories;
using ControleFinanceiro.Mobile.Views;
using ControleFinanceiro.Service.Interface;
using ControleFinanceiro.Service.Service;

namespace ControleFinanceiro.Mobile;

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
