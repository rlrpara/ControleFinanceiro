using CommunityToolkit.Mvvm.Messaging;
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

    #region [Private Methods]
    private bool isValidData()
    {
        var valid = true;
        _mensagem.Clear();

        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            _mensagem.AppendLine("O campo 'NOME' deve ser preechido");
            valid = false;
        }
        if (string.IsNullOrWhiteSpace(txtValor.Text))
        {
            _mensagem.AppendLine("O campo 'VALOR' deve ser preechido");
            valid = false;
        }
        if (!double.TryParse(txtValor.Text, out double valorSaida))
        {
            _mensagem.AppendLine("O campo 'VALOR' é inválido");
            valid = false;
        }

        if (!valid)
        {
            lblError.IsVisible = !valid;
            lblError.Text = _mensagem.ToString();
        }

        return valid;
    }
    private Transacao ObterTransacao() => new()
    {
        Codigo = _transacao.Codigo,
        Nome = txtNome.Text,
        DataLancamento = dtpLancamento.Date,
        Tipo = rbReceita.IsChecked ? (int)ETipoTransacao.Entrada : (int)ETipoTransacao.Saida,
        Valor = double.TryParse(txtValor.Text, out double valorSaida) && valorSaida >= 0 ? valorSaida : 0,
        DataCadastro = DateTime.Now,
        DataAtualizacao = DateTime.Now,
        Ativo = true
    };
    private void Salvar()
    {
        if (!isValidData())
            return;

        _transacaoService.Atualizar(ObterTransacao());

        Navigation.PopModalAsync();

        WeakReferenceMessenger.Default.Send("");
    }
    #endregion

    #region [Constructor]
    public TransacaoEdit(IBaseRepository baseRepository)
    {
        InitializeComponent();

        _mensagem = new StringBuilder();
        _baseRepository = baseRepository;
        _transacaoService = new TransacaoService(baseRepository);
    }
    #endregion

    #region [Public methods]
    private void TapGestureRecognizerTapped_To_Close(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
    public void SetTransacaoToEdit(Transacao transacao)
    {
        _transacao = transacao;
        txtNome.Text = _transacao.Nome;
        dtpLancamento.Date = _transacao.DataLancamento ?? new DateTime();
        rbReceita.IsChecked = (ETipoTransacao)_transacao.Tipo == ETipoTransacao.Entrada;
        rbDespesa.IsChecked = (ETipoTransacao)_transacao.Tipo == ETipoTransacao.Saida;
        txtValor.Text = _transacao.Valor.ToString();
    }
    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        Salvar();
    }

    #endregion
}