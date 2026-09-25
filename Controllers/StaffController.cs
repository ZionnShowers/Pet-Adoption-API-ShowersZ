using Microsoft.AspNetCore.Mvc;
using Pet_Adoption_API.Services;
using Pet_Adoption_API.Models;

namespace Pet_Adoption_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffServices _staff;

        public StaffController(IStaffServices staff)
        {
            _staff = staff;
        }


        [HttpGet("GetAll")]
        public ActionResult<List<Staff>> GetAll(bool isworking)
        {
               List<Staff> staff = _staff.GetAll(isworking);

            return Ok(staff); //return 200 status & Students
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Staff> GetById(int id)
        {
            Staff? item = _staff.GetById(id);

            if(item == null)
            {
                return NotFound($"There is no staff member with ID {id}.");
            }

            return Ok(item);
        }

        [HttpPost("Add")]
        public ActionResult<Staff> Create([FromBody] Staff newstaff)
        {
            Staff createdStaff = _staff.AddStaff(newstaff);
            return CreatedAtAction(
                nameof(GetAll),
                createdStaff
            );
        }


        [HttpPatch("edit/{id}")]
        public ActionResult<bool> Update(int id, Staff newstaff)
        {
            bool updated = _staff.EditStaff(id, newstaff);

            if(updated == false)
            {
                return NotFound($"There is no staff member with ID {id}.");
            }
            return NoContent();
        }


/*USE FOR EDITING OR TESTING
{
    "id": 1,
    "FirstName": "",
    "LastName": "",
    "Email": "",
    "Salary": 0,
    "JobPosition": "",
    "IsWorking": true
} 
USE FOR EDITING OR TESTING*/
    }
}