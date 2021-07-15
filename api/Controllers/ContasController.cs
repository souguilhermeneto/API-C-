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
        public List<Conta> Index()
        {
            return Conta.Lista();
        }// Chama o método que lista as contas
        
        [Route("/contas/{id}")]
        [HttpGet]
        public Conta Show(int id)
        {
            return Conta.BuscaPorId(id);

        }// Chama o método que lista as contas por ordem numérica conforme id digitado da tabela e coluna numero

    }
}
