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
    public class ClientesController : ControllerBase
    {

        [Route("/clientes")]
        [HttpGet]
        public List<Cliente> Index()
        {
            return Cliente.Lista();
        }// Chama o método que lista os clientes
        
        [Route("/clientes/{id}")]
        [HttpGet]
        public Cliente Show(int id)
        {
            return Cliente.BuscaPorId(id);

        }// Chama o método que lista as contas por ordem numérica conforme id digitado da tabela e coluna codcliente

    }
}
