namespace CampSleepaway.Domain
{
    public class CabinCounselor
    {
        public int CabinId { get; set; }
        public int CounselorId { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime ExitDate { get; set; }
    }
}