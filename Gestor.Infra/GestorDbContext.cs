using Gestor.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Infra;

public class GestorDbContext : DbContext
{


    public DbSet<Demanda> Demandas { get; set; }
    public DbSet<Projeto> Projetos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=DESKTOP-215IJJK;Database=Gestor;UID=DESKTOP-215IJJK\\galoc;PWD='';Integrated Security=true;trustServerCertificate=true");
    }
}
