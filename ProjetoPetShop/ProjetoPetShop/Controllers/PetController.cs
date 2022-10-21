using Microsoft.AspNetCore.Mvc;
using ProjetoPetShop.Data;
using ProjetoPetShop.Model;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("{id}")]
        public IActionResult BuscarPetPorId(int id) 
        {
            Pet pet = _context.Pets.FirstOrDefault(pet => pet.Id_Pet == id);
            if (pet != null)
            {
                return Ok(pet);
            }
            return NotFound();        
        }




        [HttpPost]
        public IActionResult addPet ([FromBody] Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarPetPorId), new { Id = pet.Id_Pet }, pet);
        }
        
    }
}
