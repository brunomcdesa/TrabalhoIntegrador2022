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
    public class PetController : Controller
    {
        private PetContext _context;

        public PetController(PetContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Pet> BuscarPets()
        {
            return _context.Pets;
        }


        //GET
        [HttpGet("{id}")]
        public IActionResult BuscarPetPorId(int id) 
        {
            Pet pet = _context.Pets.FirstOrDefault(pet => pet.IdPet == id);
            if (pet == null)
            {
                return NotFound("Pet não encontrado!");
            }
               
                    return Ok(pet);
                 
        }

        //Get por nome do pet
        
     //   [HttpGet("{nome}")]
     //  public ActionResult BuscaPetPorNome(string nome) {

     //      Pet pet = _context.Pets.FirstOrDefault(pet => pet.NomePet == nome);
      //      if (pet == null)
      //      {
     //           return NotFound("Pet não encontrado!");
      //      }

      //      return Ok(pet);
      //  }




        [HttpPost]
        public IActionResult addPet([FromBody] Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarPetPorId), new { Id = pet.IdPet }, pet);

        }

        [HttpDelete("{id}")]
        public string RemovePetPorId(int id)
        {
                Pet pet = _context.Pets.FirstOrDefault(pet => pet.IdPet == id);
                if (pet != null)
                {
                    _context.Pets.Remove(pet);
                    _context.SaveChanges();
                    return "Pet excluido com sucesso!";
                }
                return "Pet não encontrado";
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditaPetPorId(int id, [FromBody] Pet petN)
        {

            if (id != petN.IdPet)
            {
                return BadRequest();
            }

            _context.Entry(petN).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(petN == null)
                {
                    return NotFound();
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
