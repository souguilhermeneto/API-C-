using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Models;

namespace api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [Route("/")]
        [HttpGet]
        public ActionResult Index()
        {
            //return Redirect("/swagger");

            return StatusCode(200, new
            {
                Mensagem = "Bem vindo a Api com dotnetcore",
                Documentacao = "https://localhost:5001/swagger"
            });
        }
        
    }
}
