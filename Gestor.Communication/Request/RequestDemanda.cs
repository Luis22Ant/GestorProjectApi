namespace Gestor.Communication.Request;

public class RequestDemanda
{
    public Guid IdCliente { get; set; }
    public Guid IdFuncionario { get; set; }
    public Guid IdProjeto { get; set; }
    public string Descricao { get; set; } = string.Empty;
}
