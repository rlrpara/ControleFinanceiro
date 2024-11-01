using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enum;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interface;
using ControleFinanceiro.Service.Service;
using System.Text;

namespace ControleFinanceiro.Mobile.Views;

public partial class TransacaoAdd : ContentPage
{
    #region [Private Properties]
    private StringBuilder _mensagem;
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
            _mensagem.AppendLine("O campo 'VALOR' � inv�lido");
            valid = false;
        }

        if (!valid)
        {
            lblError.IsVisible = !valid;
            lblError.Text = _mensagem.ToString();
        }

        return valid;
    }
    private Transacao ObterTransacao() => new Transacao
    {
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

        _transacaoService.Adicionar(ObterTransacao());

        Navigation.PopModalAsync();

        WeakReferenceMessenger.Default.Send("");

        var count = _transacaoService.ObterTodos().Count();
        Application.Current.MainPage.DisplayAlert("Mensagem", $"Existem {count} registro(s) no banco.", "OK");
    }
    #endregion

    #region [Constructor]
    public TransacaoAdd(IBaseRepository baseRepository)
    {
        InitializeComponent();

        _mensagem = new StringBuilder();
        _transacaoService = new TransacaoService(baseRepository);
    }
    #endregion

    #region [Public Methods]
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) => Navigation.PopModalAsync();
    private void btnSalvar_Clicked(object sender, EventArgs e) => Salvar();

    #endregion
}