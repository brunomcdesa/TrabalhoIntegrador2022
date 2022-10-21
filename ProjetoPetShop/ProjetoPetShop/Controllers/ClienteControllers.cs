using Microsoft.AspNetCore.Mvc;
using ProjetoPetShop.Data;
using ProjetoPetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPetShop.Controllers
{
    
        public class ClienteControllers : Controller
        {
            private PetContext _context;
            public ClienteControllers(PetContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IEnumerable<Cliente> GetClientes()
            {
                return _context.clientes;
            }
            [HttpGet]
            public IActionResult GetClienteById(int id)
            {
                Cliente cliente = _context.clientes.FirstOrDefault(cliente => cliente.IdCliente == id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound();
            }
            [HttpPost]
            public IActionResult PostCliente([FromBody] Cliente cliente)
            {
                _context.clientes.Add(cliente);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetClienteById), new { Id = cliente.IdCliente }, cliente);
            }
        }
     }

