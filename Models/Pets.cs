namespace Pet_Adoption_API.Models
{
    public class Pets
    {
        public int id {get;set;}
        public string Name {get;set;}
        public string Species {get;set;}
        public string Breed {get;set;}
        public int Age {get;set;}
        public bool IsAdopted {get;set;}
        public bool IsDeleted {get;set;}
    }
}