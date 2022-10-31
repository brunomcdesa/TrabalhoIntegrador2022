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
    [Route("[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private PetContext _context;

        public AgendamentoController(PetContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarAgendameto([FromBody] Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarPorId), new { Id = agendamento.IdAgendamento }, agendamento);
        }

        [HttpGet]
        public IEnumerable<Agendamento> BuscarAgendamentos()

        {
            return _context.Agendamentos;

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            //Agendamento agendamento = _context.Agendamentos.FirstOrDefault(agendamento => agendamento.IdAgendamento == id );
            
            var query = _context.Agendamentos   
            .Join(_context.Pets, 
                agendamento => agendamento.IdPet,       
                pet => pet.IdPet, 
                (agendamento, pet) => new { Agendamento = agendamento, pet.NomePet, pet.Deficiencia})
            .Where(agendamentoEPet => agendamentoEPet.Agendamento.IdAgendamento == id);    

            if (query != null)
            {

                return Ok(query);
            }
            return NotFound("Não existe");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditaPetPorId(int id, [FromBody] Agendamento agendamento)
        {

            if (id != agendamento.IdAgendamento)
            {
                return BadRequest("Id deve ser igual");
            }

            _context.Entry(agendamento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (agendamento == null)
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

        [HttpDelete("{id}")]
        public string DeletaAgendamentoPorId(int id)
        {
            Agendamento agendamento = _context.Agendamentos.FirstOrDefault(agendamento => agendamento.IdAgendamento == id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                _context.SaveChanges();

                return "Deletado com sucesso";
            }
            return "Não encontrado";
        }

    }
}
