using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class get_loginController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> auth(string usuario, string password)
        {
            string retorno = "";
            string jsonInString = "{'name':'" + usuario.Trim() + "','email':'" + password.Trim() + "'}";
            
            retorno = jsonInString;
            return Ok(retorno);

        }
    }
}
