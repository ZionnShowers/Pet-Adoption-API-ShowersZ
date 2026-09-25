using Pet_Adoption_API.Models;

namespace Pet_Adoption_API.Services
{
    public interface IStaffServices
    {
        List<Staff> GetAll(bool isworking);
        Staff GetById(int id);
        Staff AddStaff(Staff newstaff);

        bool EditStaff(int id, Staff newstaff);
    }
}