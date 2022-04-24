namespace CampSleepaway.Domain
{
    public class CabinCamper
    {
        public int CabinId { get; set; }
        public int CamperId { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime ExitDate { get; set; }
    }
}