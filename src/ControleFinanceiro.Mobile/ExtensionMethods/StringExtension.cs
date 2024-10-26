using ControleFinanceiro.Mobile.Interfaces;
using ControleFinanceiro.Mobile.Repositories;
using LiteDB;

namespace ControleFinanceiro.Mobile.ExtensionMethods;

public static class StringExtension
{
    public static MauiAppBuilder RegisterDatabaseRepositories(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(options => { return new LiteDatabase(@$"Filename={AppSettings.DatabasePath};Connection=Shared;"); });

        builder.Services.AddTransient<ITransacaoRepository, TransacaoRepository>();

        return builder;
    }
}
