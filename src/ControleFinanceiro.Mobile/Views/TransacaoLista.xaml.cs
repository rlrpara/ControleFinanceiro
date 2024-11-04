using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enum;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interface;
using ControleFinanceiro.Service.Service;

namespace ControleFinanceiro.Mobile.Views;

public partial class TransacaoLista : ContentPage
{
    #region [Private Properties]
    private readonly IBaseRepository _baseRepository;
    private readonly ITransacaoService _transacaoService;
    private Color _borderOriginalBackgroundColor;
    private string _labelOriginalText;
    #endregion

    #region [Private methods]
    private void ObterDadosGrid()
    {
        var itens = _transacaoService.ObterTodos();
        cvTransacao.ItemsSource = itens;

        double receitas = itens.Where(x => x.Tipo == (int)ETipoTransacao.Entrada).Sum(a => Convert.ToDouble(a.Valor));
        double despesas = itens.Where(x => x.Tipo == (int)ETipoTransacao.Saida).Sum(a => Convert.ToDouble(a.Valor));
        double saldo = receitas - despesas;

        lblReceita.Text = receitas.ToString("C");
        lblDespesa.Text = despesas.ToString("C");
        lblSaldo.Text = saldo.ToString("C");
    }
    private async Task AnimaionBorder(Border border, bool IsDeleteAnimation)
    {
        Label label = (Label)border.Content;

        if (IsDeleteAnimation)
        {
            _borderOriginalBackgroundColor = border.BackgroundColor;
            _labelOriginalText = label.Text;

            await border.RotateYTo(90, 500);
            border.BackgroundColor = Colors.Red;
            label.TextColor = Colors.White;
            label.Text = "X";
            await border.RotateYTo(180, 500);
        }
        else
        {
            await border.RotateYTo(90, 500);
            label.TextColor = Colors.Black;
            label.Text = _labelOriginalText;
            border.BackgroundColor = _borderOriginalBackgroundColor;
            await border.RotateYTo(0, 500);
        }
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
    private async void TapGestureRecognizerTapped_ToDelete(object sender, TappedEventArgs e)
    {
        await AnimaionBorder((Border)sender, true);
        var result = await Application.Current.MainPage.DisplayAlert("Excluir", "Tem certeza que deseja excluir?", "Sim", "Não");

        if (result)
        {
            Transacao transacao = (Transacao)e.Parameter;
            _transacaoService.Excluir<Transacao>(transacao.Codigo);

            ObterDadosGrid();
        }
        else
        {
            await AnimaionBorder((Border)sender, false);
        }
    }
    #endregion
}