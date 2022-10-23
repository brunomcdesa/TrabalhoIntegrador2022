using Microsoft.AspNetCore.Mvc;
using ProjetoPetShop.Data;
using System.Collections.Generic;
using System.Linq;
using Cliente = ProjetoPetShop.Model.Cliente;

namespace ProjetoPetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private PetContext _context;

        public ClienteController(PetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PetContext> PetContexts()
        {
            return (IEnumerable<PetContext>)_context.Cliente;
        }


        [HttpGet("[id]")]
            public IActionResult GetClienteById(int id)
            {
                Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.IdCliente == id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Cliente não encontrado");


            }
            [HttpPost]
            public IActionResult PostCliente([FromBody] Cliente cliente)
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetClienteById), new { Id = cliente.IdCliente }, cliente);
            }

        [HttpDelete("{id}")]
        public string DeleteClientePorId(int id)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.IdCliente == id);
            if(cliente != null)
            {
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
                return "Cliente excluido!";
            }
            return "Cliente não encontrado, tente novamente!";
        }

        [HttpPut("{id}")]
        public IActionResult EditaClientePorId(int id)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.IdCliente == id);
            if (cliente != null)
            {
                _context.Cliente.Update(cliente);
                _context.SaveChanges();
                return Ok(cliente);
            }
            return NotFound("Cliente não encoontrado");
                }
    }
}

