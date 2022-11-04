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
        [HttpGet("/Pet/id/{id}")]
        public IActionResult BuscarPetPorId(int id)
        {
            var query = _context.Pets
            .Join(_context.Clientes,
                pet => pet.IdCliente,
                cliente => cliente.IdCliente,
                (pet, cliente) => new { Pet = pet, cliente.Nome, cliente.Cpf, cliente.Telefone, cliente.Endereco })
            .Where(petECliente => petECliente.Pet.IdPet == id);

          
            if (query == null)
            {
                return NotFound("Pet não encontrado!");
            }
                    return Ok(query);    
        }

        [HttpGet("/Pet/nome/{nome}")]
        public IActionResult BuscarPetPorNome(string nome)
        {
            var query = _context.Pets
           .Join(_context.Clientes,
               pet => pet.IdCliente,
               cliente => cliente.IdCliente,
               (pet, cliente) => new { Pet = pet, cliente.Nome, cliente.Cpf, cliente.Telefone, cliente.Endereco })
           .Where(petECliente => petECliente.Pet.NomePet == nome);
           
            if (query == null)
            {
                return NotFound("Pet não encontrado!");
            }
            return Ok(query);
        }


        [HttpPost]
        public IActionResult addPet([FromBody] Pet pet)
        {
            //  Preciso saber como faz pra pegar o cliente que esta na tabela de clientes e adicionar em pet
            //  de acordo com o id do cliente passado no corpo do post


            //foreach(Cliente cliente in _context.Clientes) { 
            //}
   

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
                return BadRequest("O ID deve ser igual!");
            }

            _context.Entry(petN).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(petN == null)
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