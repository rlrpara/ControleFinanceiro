using LiteDB;

namespace ControleFinanceiro.Mobile.Models;

public class Transacao
{
    [BsonId]
    public int Codigo { get; set; }
    public ETipo Tipo { get; set; }
    public string? Nome { get; set; }
    public DateTimeOffset Data { get; set; }
    public decimal Valor { get; set; }
}

public enum ETipo
{
    Receita = 1,
    Despesa = 2
}
