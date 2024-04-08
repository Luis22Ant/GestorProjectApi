using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Infra.Entities;

public class Demanda
{
    [Key]
    public Guid Id { get; set; }
    public Guid IdCliente { get; set; }
  
    public Guid IdFuncionario { get; set; }
    public Guid IdProjeto { get; set; }
    public string Descricao { get; set; } = string.Empty;
}
