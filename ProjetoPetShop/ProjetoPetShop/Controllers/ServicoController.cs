using Microsoft.AspNetCore.Mvc;
using ProjetoPetShop.Data;
using ProjetoPetShop.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPetShop.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class ServicoController : ControllerBase
    {
     private static  List<Servico> servicos = new List<Servico>();
     public readonly PetContext _context;

        public ServicoController(PetContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void AddServico([FromBody] Servico servico)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
        }
        [HttpGet]
        public IActionResult buscarServicos()
        {
            return Ok(_context.Servicos.ToList());
        }

    }

}
