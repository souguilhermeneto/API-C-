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
    public class ContasController : ControllerBase
    {

        [Route("/contas")]
        [HttpGet]
        public List<Cliente> Index()
        {
            return Cliente.Lista();
        }
        
        [Route("/contas/{id}")]
        [HttpGet]
        public Cliente Show(int id)
        {
            return Cliente.BuscaPorId(id);

        }

    }
}
