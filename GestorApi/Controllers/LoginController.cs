using Gestor.Application.UseCase.Login;
using Microsoft.AspNetCore.Mvc;

namespace GestorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [Route("{user},{senha}")]
        public async Task<IActionResult> Login([FromRoute] string user, [FromRoute] string senha)
        {
            var useCase = new LoginUseCase();

            var response = await useCase.Execute(user,senha);

            return Ok(response);
        }
    }
}
