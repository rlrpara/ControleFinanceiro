using CommunityToolkit.Mvvm.Messaging;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Service.Interface;
using MinhasFinancas.Service.Service;

namespace MinhasFinancas.App.Views;

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

        double receitas = itens.Where(x => x.Tipo == (int)TipoTransacao.Entrada).Sum(a => a.Valor);
        double despesas = itens.Where(x => x.Tipo == (int)TipoTransacao.Saida).Sum(a => a.Valor);
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
        Navigation.PushModalAsync(new TransacaoAdd(_baseRepository));
    }
    private void EditarRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransacaoEdit(_baseRepository));
    }

    #endregion
}