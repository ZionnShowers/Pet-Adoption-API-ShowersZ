using Pet_Adoption_API.Data;
using Pet_Adoption_API.Models;

namespace Pet_Adoption_API.Services
{
    public class StaffServices : IStaffServices
    {
        private AppDbContext _db;

        public StaffServices(AppDbContext db)
        {
            _db = db;
        }
        public List<Staff> GetAll(bool isworking)
        {
            // IEnumerable<Staff> result = _db.Staff.ToList();
            // return result.ToList();
            IEnumerable<Staff> result = _db.Staff.ToList();
            result = result.Where(p => p.IsWorking != isworking);
            return result.ToList();
        }
        public Staff GetById(int id)
        {
            Staff? item = _db.Staff.FirstOrDefault(s => s.Id == id);

            return item;
        }
        public Staff AddStaff(Staff newstaff)
        {
            newstaff.Id = 0;

            _db.Staff.Add(newstaff);
            _db.SaveChanges();

            return newstaff;

        }


        public bool EditStaff(int id, Staff newstaff)
        {
            Staff? existing = _db.Staff.FirstOrDefault(s => s.Id == id);

            if(existing == null)
            {
                return false;
            }

            existing.Salary = newstaff.Salary;
            existing.JobPosition = newstaff.JobPosition;
            _db.Staff.Update(existing);
            _db.SaveChanges();
            return true;
        }
    }
}