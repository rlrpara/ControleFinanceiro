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
        cvTransacao.ItemsSource = _transacaoService.ObterTodos();
    }
    #endregion

    #region [Constructor]
    public TransacaoLista(IBaseRepository baseRepository)
	{
		InitializeComponent();

        _baseRepository = baseRepository;
        _transacaoService = new TransacaoService(baseRepository);

        ObterDadosGrid();
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