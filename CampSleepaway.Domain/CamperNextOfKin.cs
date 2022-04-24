namespace CampSleepaway.Domain
{
    public class CamperNextOfKin
    {
        public int CamperId { get; set; }
        public int NextOfKinId { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime ExitDate { get; set; }
    }
}