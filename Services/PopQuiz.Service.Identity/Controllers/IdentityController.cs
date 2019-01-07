using Microsoft.AspNetCore.Mvc;
using PopQuiz.Service.Common.Web.Controllers;
using System.Threading.Tasks;
using PopQuiz.Service.Identity.Application.Commands.Authenticate;

namespace PopQuiz.Service.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : PopQuizServiceControllerBase
    {
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginCommand loginCommand)
        {
            return Ok(await Mediator.Send(loginCommand));
        }

        [HttpPost]
        [Route("authorize")]
        public IActionResult Authorize()
        {
            return BadRequest();
        }
    }
}
