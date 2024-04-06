using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Funcionario.GetById;

public class GetByIdUseCase
{

    private readonly GestorDbContext _dbContext;

    public GetByIdUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseFuncionarioId> Execute(Guid idFunc)
    {
        var entity = await _dbContext.Funcionarios.FindAsync(idFunc);

        if (entity is null)
            throw new NotFoundException("Não existe funcionário com este Id!");

        return new ResponseFuncionarioId()
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Usuario = entity.Usuario,
            Senha = entity.Senha,
            Salario = entity.Salario,
            Setor = entity.Setor
        };
    }
}
