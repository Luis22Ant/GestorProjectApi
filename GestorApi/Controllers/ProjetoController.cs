using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestor.Communication.Response;
using Gestor.Application.UseCase.Projeto.Register;
using Gestor.Infra.Entities;
using Gestor.Communication.Request;
using Gestor.Application.UseCase.Projeto.GetAll;
using Gestor.Application.UseCase.Projeto.GetProjectsClient;

namespace GestorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseProjeto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RequestProjeto request)
        {
            var useCase = new RegisterUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty,response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Projeto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException),StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAll()
        {
            var useCase = new GetAllUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet]
        [Route("{idCliente}")]
        [ProducesResponseType(typeof(Projeto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetProjectsClient([FromRoute] Guid idCliente)
        {
            var useCase = new GetProjectsClientUseCase();

            var response = await useCase.Execute(idCliente);

            return Ok(response);
        }
    }
}
