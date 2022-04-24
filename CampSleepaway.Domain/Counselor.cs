namespace CampSleepaway.Domain
{
    public class Counselor
    {
        public int CounselorId { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public string? Phone { get; set; }
        public string? YearsActive { get; set; }
        public List<Cabin> Cabins { get; set; } = new List<Cabin>();
    }
}