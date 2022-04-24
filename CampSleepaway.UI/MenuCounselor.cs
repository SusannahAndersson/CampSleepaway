using CampSleepaway.Data;
using CampSleepaway.Domain;

namespace CampSleepaway.UI
{
    internal class MenuCounselor
    {
        public static CampSleepawayContext _context = new CampSleepawayContext();

        public static void AddCounselor()
        {
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            //Console.WriteLine("Years active as counselor: ");
            //string yearsActive = Console.ReadLine();
            var counselor = new Counselor
            {
                FirstName = firstName,
                Surname = surname /*, YearsActive = yearsActive*/
            };
            _context.Counselors.Add(counselor);
            _context.SaveChanges();
            Console.WriteLine($"[ {firstName} ] successfully added");
        }

        public static void DeleteCounselor()
        {
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            var counselor = _context.Counselors.Where(c => c.FirstName == firstName).FirstOrDefault();
            _context.Counselors.Remove(counselor);
            _context.SaveChanges();
            Console.WriteLine($"[ {firstName} ] successfully deleted");
        }

        public static void UpdateCounselor()
        {
            Console.WriteLine("Counselors current/old surname:");
            string surname = Console.ReadLine();
            var counselors = _context.Counselors.Where(c => c.Surname == surname).FirstOrDefault();
            if (counselors is Counselor)
            {
                Console.WriteLine("Counselors new surname:");
                string newSurname = Console.ReadLine();
                counselors.Surname = newSurname;
                _context.SaveChanges();
                Console.WriteLine($"[ {newSurname} ] successfully updated");
            }
            else
            {
                Console.WriteLine("Invalid current/old surname");
            }
        }

        public static void SearchCounselor()
        {
            Console.WriteLine("Search counselor by first name: ");
            string firstName = Console.ReadLine();
            var counselor = _context.Counselors.Where(cou => cou.FirstName == firstName).FirstOrDefault();
            if (counselor is Counselor)
            {
                var counselors = _context.Counselors.Where(c => c.FirstName == firstName).ToList();
                foreach (var c in counselors)
                {
                    Console.WriteLine($"Counselor count is {counselors.Count} with CounselorId {c.CounselorId} for {c.FirstName} {c.Surname} YearsActive: {c.YearsActive}");
                }
            }
            else
            {
                Console.WriteLine("Invalid name");
            }
        }

        public static void ListAllCounselors()
        {
            var counselors = _context.Counselors.ToList();
            Console.WriteLine($"\tNumber of counselors: {counselors.Count}");
            foreach (var counselor in counselors)
            {
                Console.WriteLine($"Name: {counselor.FirstName} | Surname: {counselor.Surname} | Counselor Id: {counselor.CounselorId}");
            }
        }

        public static void AddCabinCounselor()
        {
            Console.WriteLine("\n\n\tEnter cabin id:");
            int uiCabinId = int.Parse(Console.ReadLine());
            var cabinCounselor = _context.CabinCounselor.Where(cabcao => cabcao.CabinId == uiCabinId).ToList();
            if (cabinCounselor.Count >= 1)
            {
                Console.WriteLine($"Cabin Id {uiCabinId} is full");
            }
            else if (cabinCounselor.Count < 1)
            {
                Console.WriteLine("Enter counselor Id:");
                int uiCounselorId = int.Parse(Console.ReadLine());
                DateTime enterDate = DateTime.Today;
                var cabincounselor = new CabinCounselor { CabinId = uiCabinId, CounselorId = uiCounselorId, EnterDate = enterDate };
                _context.CabinCounselor.Add(cabincounselor);
                _context.SaveChanges();
                Console.WriteLine($"Counselor id {uiCounselorId} successfully added to Cabin {uiCabinId}");
            }
        }
    }
}