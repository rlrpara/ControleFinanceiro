using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enum;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interface;
using ControleFinanceiro.Service.Service;
using System.Text;
using System.Transactions;

namespace ControleFinanceiro.Mobile.Views;

public partial class TransacaoLista : ContentPage
{
    #region [Private Properties]
    private readonly IBaseRepository _baseRepository;
    private readonly ITransacaoService _transacaoService;
    #endregion

    #region [Private methods]
    private void ObterDadosGrid()
    {
        var itens = _transacaoService.ObterTodos();
        cvTransacao.ItemsSource = itens;

        double receitas = itens.Where(x => x.Tipo == (int)ETipoTransacao.Entrada).Sum(a => a.Valor);
        double despesas = itens.Where(x => x.Tipo == (int)ETipoTransacao.Saida).Sum(a => a.Valor);
        double saldo = receitas - despesas;

        lblReceita.Text = receitas.ToString("C");
        lblDespesa.Text = despesas.ToString("C");
        lblSaldo.Text = saldo.ToString("C");
    }
    #endregion

    #region [Constructor]
    public TransacaoLista(IBaseRepository baseRepository)
    {
        InitializeComponent();

        _baseRepository = baseRepository;
        _transacaoService = new TransacaoService(baseRepository);

        ObterDadosGrid();

        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) => { ObterDadosGrid(); });
    }
    #endregion

    #region [Public Methods]
    private void NovoRegistro_Clicked(object sender, EventArgs e)
    {
        var TransacaoAdd = Handler.MauiContext.Services.GetService<TransacaoAdd>();
        Navigation.PushModalAsync(TransacaoAdd);
    }
    private void TapGestureRecognizer_Tapped_To_TransactionEdit(object sender, TappedEventArgs e)
    {
        var TransacaoEdit = Handler.MauiContext.Services.GetService<TransacaoEdit>();
        var transacao = (Transacao)((TapGestureRecognizer)((Grid)sender).GestureRecognizers[0]).CommandParameter;
        TransacaoEdit.SetTransacaoToEdit(transacao);

        Navigation.PushModalAsync(TransacaoEdit);
    }

    #endregion
}