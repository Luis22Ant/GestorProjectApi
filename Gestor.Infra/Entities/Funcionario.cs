using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Infra.Entities;

public class Funcionario
{
   
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public double Salario { get; set; }
    public string Setor { get; set; } = string.Empty;

    [ForeignKey("IdFuncionario")]
    public List<Demanda> Demandas { get; set; } = [];
}
