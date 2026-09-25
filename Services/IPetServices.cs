using Pet_Adoption_API.Models;

namespace Pet_Adoption_API.Services
{
    public interface IPetServices
    {

        List<Pets> GetAll(bool isdeleted, bool isadopted);

        Pets AddPet(Pets newpets);

        bool EditPet(int id, Pets newpets);

        bool AdoptPet(int id);
        bool DeletePet(int id);
        bool RestorePet(int id);
        Pets GetById(int id);
    }
}