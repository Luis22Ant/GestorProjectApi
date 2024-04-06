using Gestor.Application.UseCase.Cliente.Register;
using Gestor.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestor.Communication.Request;
using Gestor.Application.UseCase.Cliente.GetAll;
using Gestor.Application.UseCase.Cliente.GetById;
using Gestor.Application.UseCase.Cliente.Update;
using Gestor.Application.UseCase.Cliente.Delete;

namespace GestorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCliente),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseException),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseException),StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] RequestCliente request)
        {
            var useCase = new RegisterUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty,response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientes),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException),StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAll()
        {
            var useCase = new GetAllUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet]
        [Route("{idCliente}")]
        [ProducesResponseType(typeof(ResponseAllClientes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetById([FromRoute] Guid idCliente)
        {
            var useCase = new GetByIdUseCase();

            var response = await useCase.Execute(idCliente);

            return Ok(response);
        }

        [HttpPut]
        [Route("{idCliente}")]
        [ProducesResponseType(typeof(ResponseCliente),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException),StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Update([FromRoute] Guid idCliente, [FromBody] RequestCliente request)
        {

            var useCase = new UpdateUseCase();

            var response = await useCase.Execute(idCliente,request);

            return Ok(response);

        }

        [HttpDelete]
        [Route("{idCliente}")]
        [ProducesResponseType(typeof(ResponseCliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete([FromRoute] Guid idCliente)
        {

            var useCase = new DeleteUseCase();

            var response = await useCase.Execute(idCliente);

            return Ok(response);

        }
    }
}
