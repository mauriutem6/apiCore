using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System.Text;
using webapi.Model;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class get_api1Controller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get(string email, string password)
        {
            string retorno = "";
            using (var client = new HttpClient())
            {
                string url = "http://restapi.adequateshop.com/api/authaccount/login";
                string jsonInString = "{'email':'" + email + "','password':'" + password + "'}";
                var responseTask = client.PostAsync(url, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    retorno = result.Content.ReadAsStringAsync().Result;
                    return Ok(retorno);
                }
            }
            return Ok(retorno);
        }
    }
}
