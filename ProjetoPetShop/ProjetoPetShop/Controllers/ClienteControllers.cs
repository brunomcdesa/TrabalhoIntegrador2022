using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPetShop.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Cliente> PetContexts()
        {
            return _context.Clientes;
        }


        [HttpGet("{id}")]
            public IActionResult GetClienteById(int id)
            {
                Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.IdCliente == id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Cliente não encontrado");


            }
            [HttpPost]
            public IActionResult PostCliente([FromBody] Cliente cliente)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetClienteById), new { Id = cliente.IdCliente }, cliente);
            }

        [HttpDelete("{id}")]
        public string DeleteClientePorId(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.IdCliente == id);
            if(cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return "Cliente excluido!";
            }
            return "Cliente não encontrado, tente novamente!";
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditaClientePorId(int id, [FromBody] Cliente clienteN)
        {
            if (id != clienteN.IdCliente)
            {
                return BadRequest("Id deve ser igual!");
            }

            _context.Entry(clienteN).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (clienteN == null)
                {
                    return NotFound("Id não encontrado!");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}

