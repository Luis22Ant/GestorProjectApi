using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Demanda.Update;

public class UpdateUseCase
{
    private readonly GestorDbContext _dbContext;

    public UpdateUseCase()
    {
        _dbContext = new GestorDbContext();
    }

    public async Task<ResponseIdDemanda> Execute(Guid idDemanda,RequestDemanda request)
    {
        ValidateDemanda(request);

        var entity = await _dbContext.Demandas.FirstOrDefaultAsync(d => d.Id == idDemanda);

        if (entity is null)
            throw new NotFoundException("Demanda não existe!");

        entity.IdCliente = request.IdCliente;
        entity.Descricao = request.Descricao;
        entity.IdProjeto = request.IdProjeto;
        entity.IdFuncionario = request.IdFuncionario;
        entity.IdCliente = request.IdCliente;
       
        _dbContext.Demandas.Update(entity);
        await _dbContext.SaveChangesAsync();


        return new ResponseIdDemanda
        {
            Id = idDemanda
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
