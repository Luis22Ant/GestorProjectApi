
using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Funcionario.Register;

public class RegisterUseCase
{
    private readonly GestorDbContext _dbContext;

    public RegisterUseCase()
    {
        _dbContext = new GestorDbContext();
    }

    public async Task<ResponseRegisterFuncionario> Execute(RequestFuncionario request)
    {

        ValidateRequest(request);

        var entity = new Infra.Entities.Funcionario
        {
            Nome = request.Nome,
            Salario = request.Salario,
            Usuario = request.Usuario,
            Senha = request.Senha,
            Setor = request.Setor
        };

        await _dbContext.Funcionarios.AddAsync(entity);
        await _dbContext.SaveChangesAsync();


        return new ResponseRegisterFuncionario
        {
            Id = entity.Id
        };
    }

    private void ValidateRequest(RequestFuncionario request)
    {

        var userExist = _dbContext.Funcionarios.FirstOrDefault(op => op.Usuario == request.Usuario);

        if (userExist != null)
            throw new ConflictException("Esse usuário já existe!");

        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ErrorBadRequestException("Nome é invalido!");

        if (string.IsNullOrWhiteSpace(request.Usuario))
            throw new ErrorBadRequestException("Usuário é invalido!");

        if (string.IsNullOrWhiteSpace(request.Setor))
            throw new ErrorBadRequestException("Setor é invalido!");

        if (string.IsNullOrWhiteSpace(request.Senha))
            throw new ErrorBadRequestException("Senha é invalido!");

        if (request.Salario <= 0)
            throw new ErrorBadRequestException("Salário é invalido!");

    }
}
