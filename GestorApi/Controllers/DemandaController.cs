using Gestor.Application.UseCase.Demanda.GetAllDemandaFunc;
using Gestor.Application.UseCase.Demanda.Register;
using Gestor.Application.UseCase.Demanda.Update;
using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandaController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseIdDemanda), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseIdDemanda), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseIdDemanda), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Register([FromBody] RequestDemanda request)
        {
        
                var useCase = new RegisterUseCase();

                var response = await useCase.Execute(request);

                return Created(string.Empty, response);
        }


        [HttpGet]
        [Route("{idFunc}")]
        [ProducesResponseType(typeof(ResponseIdDemanda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseIdDemanda), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAllDemandaFromFunc([FromRoute] Guid idFunc)
        {
            var useCase = new GetAllDemandaFuncUseCase();

            var response = await useCase.Execute(idFunc);

            return Ok(response.Demandas);
        }

        [HttpPut]
        [Route("{idDemanda}")]
        [ProducesResponseType(typeof(ResponseIdDemanda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseException),StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Update([FromRoute] Guid idDemanda, [FromBody] RequestDemanda request)
        {
            var useCase = new UpdateUseCase();

            var response = await useCase.Execute(idDemanda,request);

            return Ok(response);
        }
    }
}
