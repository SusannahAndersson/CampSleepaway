namespace CampSleepaway.Domain
{
    public class NextOfKin
    {
        public int NextOfKinId { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public string? Phone { get; set; }
        public List<Camper> Campers { get; set; } = new List<Camper>();
        public string nokFullName => $"{FirstName} {Surname}";
    }
}