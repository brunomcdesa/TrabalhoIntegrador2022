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
    public class FuncionariosController : ControllerBase
    {
        private PetContext _petContext;

        public FuncionariosController(PetContext context)
        {
            _petContext = context;
        }
        [HttpGet]
        public IActionResult BuscarFuncionarios
        ()
        {
            return Ok(_petContext.Funcionarios
            .ToList());
        }
        [HttpGet("{Id}")]
        public IActionResult BuscarFuncionarios
        PorId(int Id)
        {
            Funcionarios FuncionariosPet = _petContext.Funcionarios
            .FirstOrDefault(FuncionariosPet => FuncionariosPet.IdFuncionarios == Id);
            if(FuncionariosPet != null)
            {
                return Ok(FuncionariosPet);
            }
            return NotFound("serviço não encontrado");
        }
        [HttpPost]
        public IActionResult AdicionarFuncionarios ([FromBody] Funcionarios Funcionarios)
        {
            _petContext.Funcionarios
            .Add(Funcionarios);
            _petContext.SaveChanges();
            return CreatedAtAction(nameof(BuscarFuncionarios
            PorId), new { Id = Funcionarios.IdFuncionarios }, Funcionarios);
        }
        [HttpDelete("{Id}")]
        public void DeletaFuncionarios(int Id)
        {
            var Funcionarios = _petContext.Funcionarios
            .FirstOrDefault(Funcionarios => Funcionarios.IdFuncionarios == Id);
            if(Funcionarios != null)
            {
                _petContext.Funcionarios
                .Remove(Funcionarios);
                _petContext.SaveChanges();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarFuncionarioPorId (int id, [FromBody]Funcionarios editFuncionarios)
        {
                           
            if (id != editFuncionarios.IdFuncionarios)
            {
                return BadRequest("Id deve ser igual!"); 
            }
            _petContext.Entry(editFuncionarios).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await _petContext.SaveChangesAsync();
            }   
            catch (DbUpdateConcurrencyException)
            {
                if(editFuncionarios == null)
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
