using Microsoft.AspNetCore.Mvc;
using Pet_Adoption_API.Services;
using Pet_Adoption_API.Models;

namespace Pet_Adoption_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetServices _pets;

        public PetController(IPetServices pets)
        {
            _pets = pets; //supplying the empty variable with methods from our StudentServices class
        }

        [HttpGet("GetAllPets")]
        public ActionResult<List<Pets>> GetAll(bool isdeleted)
        {
            //We are storing our students from our Database into the students List
            // if (_pets.IsDeleted)
                List<Pets> pets = _pets.GetAll(isdeleted);

            return Ok(pets); //return 200 status & Students
        }

        [HttpPost("Create")]
        public ActionResult<Pets> Create([FromBody] Pets newpets)
        {
            Pets createdPet = _pets.AddPet(newpets);
            return CreatedAtAction(
                nameof(GetAll),
                createdPet
            );
        }

        [HttpPut("edit/{id}")]
        public ActionResult<bool> Update(int id, Pets newpets)
        {
            bool updated = _pets.EditPet(id, newpets);

            if(updated == false)
            {
                return NotFound($"There is no pet with ID {id}.");
            }
            return NoContent();
        }

/*USE FOR EDITING OR TESTING
{
     "id": 2,
     "name": "Jake",
     "species": "Dog",
     "breed": "Cockapoo",
     "age": 8,
     "isAdopted": false,
     "isDeleted": false
} 
USE FOR EDITING OR TESTING*/

        [HttpPut("adopt/{id}")]
        public ActionResult<bool> Adopt(int id, Pets newpets)
        {
            bool updated = _pets.AdoptPet(id, newpets);

            if(updated == false)
            {
                return NotFound($"There is no pet with ID {id}.");
            }
            return NoContent();
        }

        [HttpPut("delete/{id}")]
        public ActionResult<bool> Delete(int id, Pets newpets)
        {
            bool updated = _pets.DeletePet(id, newpets);

            if(updated == false)
            {
                return NotFound($"There is no pet with ID {id}.");
            }
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public ActionResult<bool> Restore(int id, Pets newpets)
        {
            bool updated = _pets.RestorePet(id, newpets);

            if(updated == false)
            {
                return NotFound($"There is no pet with ID {id}.");
            }
            return NoContent();
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Pets> GetById(int id)
        {
            Pets? item = _pets.GetById(id);

            if(item == null)
            {
                return NotFound($"There is no pet with ID {id}.");
            }

            return Ok(item);
        }

        // [HttpDelete("delete/{id}")]
        // public ActionResult<bool> DeleteItem(int id)
        // {
        //     bool deleted = _pets.Delete(id);

        //     if(deleted == false)
        //     {
        //         return NotFound($"There is no pet with ID {id}.");
        //     }

        //     return NoContent();
        // }

    }
}