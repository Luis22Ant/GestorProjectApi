using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Demanda.Register;

public class RegisterUseCase
{
    private readonly GestorDbContext _dbContext;

    public RegisterUseCase()
    {
        _dbContext = new GestorDbContext();
    }

    public async Task<ResponseIdDemanda> Execute(RequestDemanda request)
    {

        ValidateDemanda(request);

        var entity = new Infra.Entities.Demanda
        {
            IdCliente = request.IdCliente,
            IdFuncionario = request.IdFuncionario,
            IdProjeto = request.IdProjeto,
            Descricao = request.Descricao
        };

        _dbContext.Demandas.Add(entity);
        await _dbContext.SaveChangesAsync();


        return new ResponseIdDemanda
        {
            Id = entity.Id
        };
    }

    private void ValidateDemanda(RequestDemanda request)
    {
        var Cliente = _dbContext.Clientes.FirstOrDefault(c => c.Id == request.IdCliente);
        var Func = _dbContext.Funcionarios.FirstOrDefault(f => f.Id == request.IdFuncionario);
        var Project = _dbContext.Projetos.FirstOrDefault(p => p.Id == request.IdProjeto);


        if (string.IsNullOrWhiteSpace(request.Descricao))
            throw new ErrorBadRequestException("Descrição inválida!");

        if (Cliente is null)
            throw new NotFoundException("Id de cliente inválido!");

        if (Func is null)
            throw new NotFoundException("Id de funcionário inválido!");

        if (Project is null)
            throw new NotFoundException("Id de projeto inválido!");
    }
}
