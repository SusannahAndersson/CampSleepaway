namespace CampSleepaway.Domain
{
    public class Camper
    {
        public int CamperId { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public string? Allergies { get; set; }
        public List<Cabin> Cabins { get; set; } = new List<Cabin>();
        public List<NextOfKin> NextOfKins { get; set; } = new List<NextOfKin>();
    }
}