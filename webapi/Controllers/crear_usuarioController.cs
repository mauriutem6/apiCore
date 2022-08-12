using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System.Text;
using webapi.Model;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class crear_usuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get(string name, string email, string password)
        {
            try
            {
                string retorno = "";
                using (var client = new HttpClient())
                {
                    string url = "http://restapi.adequateshop.com/api/authaccount/registration";
                    string jsonInString = "{'name':'" + name.Trim() + "','email':'" + email.Trim() + "','password':'" + password.Trim() + "'}";
                    var responseTask = client.PostAsync(url, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        retorno = result.Content.ReadAsStringAsync().Result;
                        return Ok(retorno);
                    }
                }
                return Ok("{'error':'1'}");
            }
            catch {
                return Ok("{'error':'1'}");
            }
        }
    }
}
