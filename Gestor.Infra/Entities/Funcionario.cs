using System.ComponentModel.DataAnnotations;

namespace Gestor.Infra.Entities;

public class Funcionario
{
   
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public double Salario { get; set; }
}
