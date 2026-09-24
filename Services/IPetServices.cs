using Pet_Adoption_API.Models;

namespace Pet_Adoption_API.Services
{
    public interface IPetServices
    {

        List<Pets> GetAll(bool isdeleted);

        Pets AddPet(Pets newpets);

        bool EditPet(int id, Pets newpets);

        bool AdoptPet(int id, Pets newpets);
        bool DeletePet(int id, Pets newpets);
        bool RestorePet(int id, Pets newpets);
        Pets GetById(int id);
    }
}