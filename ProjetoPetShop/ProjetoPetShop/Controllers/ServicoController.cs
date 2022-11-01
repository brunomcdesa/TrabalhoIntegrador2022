using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPetShop.Data;
using ProjetoPetShop.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPetShop.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class ServicoController : ControllerBase
    {
        private PetContext _petContext;

        public ServicoController(PetContext context)
        {
            _petContext = context;
        }
        [HttpGet]
        public IActionResult BuscarServicos()
        {
            return Ok(_petContext.Servicos.ToList());
        }
        [HttpGet("{Id}")]
        public IActionResult BuscarServicosPorId(int Id)
        {
            Servico servicoPet = _petContext.Servicos.FirstOrDefault(servicoPet => servicoPet.IdServico == Id);
            if(servicoPet != null)
            {
                return Ok(servicoPet);
            }
            return NotFound("serviço não encontrado");
        }
        [HttpPost]
        public IActionResult AdicionaServico ([FromBody] Servico servico)
        {
            _petContext.Servicos.Add(servico);
            _petContext.SaveChanges();
            return CreatedAtAction(nameof(BuscarServicosPorId), new { Id = servico.IdServico }, servico);
        }
        [HttpDelete("{Id}")]
        public void DeletaServico(int Id)
        {
            var servico = _petContext.Servicos.FirstOrDefault(servico => servico.IdServico == Id);
            if(servico != null)
            {
                _petContext.Servicos.Remove(servico);
                _petContext.SaveChanges();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPedidoPorId (int id, [FromBody]Servico editServico)
        {
                           
            if (id != editServico.IdServico)
            {
                return BadRequest("Id deve ser igual!"); 
            }
            _petContext.Entry(editServico).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await _petContext.SaveChangesAsync();
            }   
            catch (DbUpdateConcurrencyException)
            {
                if(editServico == null)
                {
                    return NotFound("Id não encontrado");
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
