using ControleFinanceiro.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Domain.Entities;

[Table("TRANSACAO")]
public class Transacao : EntityBase
{
    #region [Private properties]
    private int _tipo;
    private string _valor;
    private string? _nome;
    private DateTime? _dataLancamento;
    #endregion


    #region [Public methods]
    [Nota()]
    [Column(name: "TIPO", Order = 2)]
    public int Tipo
    {
        get { return _tipo; }
        set { _tipo = value; }
    }

    [Nota()]
    [Column(name: "NOME", Order = 3)]
    public string? Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    [Nota()]
    [Column(name: "DATA_LANCAMENTO", Order = 4)]
    public DateTime? DataLancamento
    {
        get { return _dataLancamento; }
        set { _dataLancamento = value; }
    }

    [Nota()]
    [Column(name: "VALOR", Order = 5)]
    public string Valor
    {
        get { return _valor; }
        set { _valor = value; }
    }
    #endregion
}
