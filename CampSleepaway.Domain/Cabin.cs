using System.ComponentModel.DataAnnotations;

namespace CampSleepaway.Domain
{
    public class Cabin
    {
        [Key]
        public int CabinId { get; set; }

        public string? Name { get; set; }
        public List<Camper> Campers { get; set; } = new List<Camper>();
        public List<Counselor> Counselors { get; set; } = new List<Counselor>();
        public int CounselorId { get; set; }
    }
}