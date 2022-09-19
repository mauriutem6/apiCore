using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using webapi.Model;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class get_api2Controller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            var user = await github.User.Get("half-ogre");

            //var tokenAuth = new Credentials("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"); // mauriutem@gmail.com
            var tokenAuth = new Credentials("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"); // mauriutem@yahoo.es
            

            github.Credentials = tokenAuth;

            //IReadOnlyList<Repository> lista = github.Repository.GetAllForCurrent().Result.ToList();

            IReadOnlyList<Repository> lista = github.Repository.GetAllForCurrent().Result.OrderByDescending(o=>o.CreatedAt.Date).ToList();//github.Repository.GetAllForCurrent().Result.OrderBy(o => o.CreatedAt.Date).ToList();

            List<repoClass> return_list = new List<repoClass>();

            foreach (Repository item in lista.Take(100))
            {
                repoClass modelo = new repoClass();
                modelo.FullName = item.FullName;
                return_list.Add(modelo);
            }



            return Ok(return_list);
        }

    }
}
