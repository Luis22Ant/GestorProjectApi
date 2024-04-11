namespace Gestor.Communication.Response;

public class ResponseFuncionarioId
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Setor { get; set; } = string.Empty;
    public double Salario { get; set; }
}
