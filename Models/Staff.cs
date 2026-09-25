namespace Pet_Adoption_API.Models
{
    public class Staff
    {
        public int Id {get;set;}
        public string FirstName {get;set;} = string.Empty;
        public string LastName {get;set;} = string.Empty;
        public string Email {get;set;} = string.Empty;
        public double Salary {get;set;}
        public string JobPosition {get;set;} = string.Empty;
        public bool IsWorking {get;set;}
    }
}