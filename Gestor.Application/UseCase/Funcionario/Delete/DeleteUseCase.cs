using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Funcionario.Delete;

public class DeleteUseCase
{
    private readonly GestorDbContext _dbContext;

    public DeleteUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseRegisterFuncionario> Execute(Guid idFunc)
    {
        var entity = await _dbContext.Funcionarios.FindAsync(idFunc);

        if(entity != null)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException("Esse funcionário não existe!");
        }

        return new ResponseRegisterFuncionario
        {
            Id = idFunc
        };
    }
}
