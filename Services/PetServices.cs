using Pet_Adoption_API.Data;
using Pet_Adoption_API.Models;

namespace Pet_Adoption_API.Services
{
    public class PetServices : IPetServices
    {
        private AppDbContext _db;

        public PetServices(AppDbContext db) //Constructor must have same name as our class
        {
            _db = db;
            //When our StudentServices Class is called
            //The Contructor Runs automaticcally
            //We pass in our database as a parameter and set inside of our _db variable
        }

        public List<Pets> GetAll(bool isdeleted, bool isadopted)
        {
            IEnumerable<Pets> result = _db.Pets.ToList();
            result = result.Where(p => p.IsDeleted == isdeleted && p.IsAdopted == isadopted);
            return result.ToList();
        }

        public Pets AddPet(Pets newpets)
        {
            //The Database assigns the Id, so we can ignore any id the client sent
            newpets.id = 0;

            _db.Pets.Add(newpets); //Stages the add
            _db.SaveChanges(); //Actually writes it to our students.db

            return newpets;

        }

        public bool EditPet(int id, Pets newpets)
        {
            Pets? existing = _db.Pets.FirstOrDefault(i => i.id == id);

            if(existing == null)
            {
                return false;
            }

            existing.Name = newpets.Name;
            existing.Species = newpets.Species;
            existing.Breed = newpets.Breed;
            existing.Age = newpets.Age;
            existing.IsAdopted = newpets.IsAdopted;
            existing.IsDeleted = newpets.IsDeleted;
            _db.Pets.Update(existing);
            _db.SaveChanges();
            return true;
        }

        public bool AdoptPet(int id)
        {
            Pets? existing = _db.Pets.FirstOrDefault(c => c.id == id);

            if(existing == null || existing.IsAdopted == true || existing.IsDeleted == true)
            {
                return false;
            }
            existing.IsAdopted = true;
            _db.Pets.Update(existing);
            _db.SaveChanges();
            return true;
            //When AdoptPet/id is entered, automatically change IsAdopted to true
            
        }

        public bool DeletePet(int id)
        {
            Pets? existing = _db.Pets.FirstOrDefault(c => c.id == id);

            if(existing == null)
            {
                return false;
            }
            existing.IsDeleted = true;
            _db.Pets.Update(existing);
            _db.SaveChanges();
            return true;
            
        }

        public bool RestorePet(int id)
        {
            Pets? existing = _db.Pets.FirstOrDefault(c => c.id == id);

            if(existing == null)
            {
                return false;
            }
            existing.IsDeleted = false;
            _db.Pets.Update(existing);
            _db.SaveChanges();
            return true;
            
        }

        public Pets GetById(int id)
        {
            Pets? item = _db.Pets.FirstOrDefault(c => c.id == id);

            return item;
        }

        // public bool Delete(int id)
        // {
        //     PetItem? existingItem = _db.FirstOrDefault(t => t.Id == id);

        //     if (existingItem == null)
        //     {
        //         return false;
        //     }

        //     _db.Remove(existingItem);

        //     return true;
        // }
    }
}