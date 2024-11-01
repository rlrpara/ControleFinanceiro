using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enum;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interface;
using ControleFinanceiro.Service.Service;
using System.Text;

namespace ControleFinanceiro.Mobile.Views;

public partial class TransacaoEdit : ContentPage
{
    #region [Private Properties]
    private StringBuilder _mensagem;
    private Transacao _transacao;
    private readonly IBaseRepository _baseRepository;
    private readonly ITransacaoService _transacaoService;
    #endregion

    #region [Constructor]
    public TransacaoEdit(IBaseRepository baseRepository)
    {
        InitializeComponent();

        _baseRepository = baseRepository;
        _transacaoService = new TransacaoService(baseRepository);
    }
    #endregion

    #region [Public methods]
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
    public void SetTransacaoToEdit(Transacao transacao)
    {
        _transacao = transacao;
        txtNome.Text = _transacao.Nome;
        dtpData.Date = _transacao.DataLancamento ?? new DateTime();
        rbReceita.IsChecked = (ETipoTransacao)_transacao.Tipo == ETipoTransacao.Entrada;
        rbReceita.IsChecked = (ETipoTransacao)_transacao.Tipo == ETipoTransacao.Saida;
        txtValor.Text = _transacao.Valor.ToString();
    }
    #endregion
}