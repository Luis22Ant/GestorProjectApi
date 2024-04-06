using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Funcionario.Update;

public class UpdateUseCase
{
    private readonly GestorDbContext _dbContext;

    public UpdateUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseRegisterFuncionario> Execute(Guid idFunc, RequestFuncionario request)
    {
        ValidateRequest(request, idFunc);

        var entity = await _dbContext.Funcionarios.FindAsync(idFunc);

        if (entity != null)
        {
            entity.Nome = request.Nome;
            entity.Senha = request.Senha;
            entity.Usuario = request.Usuario;
            entity.Salario = request.Salario;
            entity.Setor = request.Setor;

            _dbContext.Funcionarios.Update(entity);
            await _dbContext.SaveChangesAsync();

            return new ResponseRegisterFuncionario()
            {
                Id = idFunc
            };
        }
        else
        {
            throw new NotFoundException("Funcionário não existe!");
        }
    }


    private void ValidateRequest(RequestFuncionario request, Guid idFunc)
    {

        var userExist = _dbContext.Funcionarios.FirstOrDefault(op => op.Usuario == request.Usuario && op.Id != idFunc );

        if (userExist != null)
            throw new ConflictException("Esse usuário já existe!");

        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ErrorBadRequestException("Nome é invalido!");

        if (string.IsNullOrWhiteSpace(request.Usuario))
            throw new ErrorBadRequestException("Usuário é invalido!");

        if (string.IsNullOrWhiteSpace(request.Senha))
            throw new ErrorBadRequestException("Senha é invalido!");

        if (string.IsNullOrWhiteSpace(request.Setor))
            throw new ErrorBadRequestException("Setor é invalido!");

        if (request.Salario <= 0)
            throw new ErrorBadRequestException("Salário é invalido!");

    }
}
