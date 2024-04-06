using Gestor.Application.UseCase.Funcionario.Delete;
using Gestor.Application.UseCase.Funcionario.GetAll;
using Gestor.Application.UseCase.Funcionario.GetById;
using Gestor.Application.UseCase.Funcionario.Register;
using Gestor.Application.UseCase.Funcionario.Update;
using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace GestorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //Registrar um funcionário
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterFuncionario), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] RequestFuncionario request)
        {
            var useCase = new RegisterUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }


        //Atualizar um funcionário
        [HttpPut]
        [Route("{IdFunc}")]
        [ProducesResponseType(typeof(ResponseRegisterFuncionario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update([FromRoute] Guid IdFunc, [FromBody] RequestFuncionario request)
        {
            var useCase = new UpdateUseCase();
            var response = await useCase.Execute(IdFunc, request);

            return Ok(response);
        }

        //Deletar um funcionário
        [HttpDelete]
        [Route("{idFunc}")]
        [ProducesResponseType(typeof(ResponseRegisterFuncionario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete([FromRoute] Guid idFunc)
        {
            var useCase = new DeleteUseCase();

            var response = await useCase.Execute(idFunc);

            return Ok(response);
        }

        //Buscar todos os funcionários
        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllFuncionarios), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAll()
        {
            var useCase = new GetAllUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        //Buscar um funcionário específico
        [HttpGet]
        [Route("{idFunc}")]
        [ProducesResponseType(typeof(ResponseRegisterFuncionario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetById([FromRoute] Guid idFunc)
        {
            var useCase = new GetByIdUseCase();

            var response = await useCase.Execute(idFunc);

            return Ok(response);
        }
    }
}
