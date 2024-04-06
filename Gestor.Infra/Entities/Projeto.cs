namespace Gestor.Infra.Entities;

public class Projeto
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public double Valor { get; set; }
    public Guid IdCliente { get; set; }

    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

}
