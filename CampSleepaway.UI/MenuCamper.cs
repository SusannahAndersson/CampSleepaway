using CampSleepaway.Data;
using CampSleepaway.Domain;

namespace CampSleepaway.UI
{
    public class MenuCamper
    {
        public static CampSleepawayContext _context = new CampSleepawayContext();

        public static void AddCamper()
        {
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Allergies: ");
            string allergies = Console.ReadLine();
            var camper = new Camper { FirstName = firstName, Surname = surname, Allergies = allergies };
            _context.Campers.Add(camper);
            _context.SaveChanges();
            Console.WriteLine($"[ {firstName} ] successfully added");
        }

        public static void DeleteCamper()
        {
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            var camper = _context.Campers.Where(c => c.FirstName == firstName).FirstOrDefault();
            _context.Campers.Remove(camper);
            _context.SaveChanges();
            Console.WriteLine($"[ {firstName} ] successfully deleted");
        }

        public static void UpdateCamper()
        {
            Console.WriteLine("Campers current/old surname:");
            string surname = Console.ReadLine();
            var campers = _context.Campers.Where(c => c.Surname == surname).FirstOrDefault();
            if (campers is Camper)
            {
                Console.WriteLine("Campers new surname:");
                string newSurname = Console.ReadLine();
                campers.Surname = newSurname;
                _context.SaveChanges();
                Console.WriteLine($"[ {newSurname} ] successfully updated");
            }
            else
            {
                Console.WriteLine("Invalid current/old surname");
            }
        }

        public static void SearchCamper()
        {
            Console.WriteLine("Search camper by first name: ");
            string firstName = Console.ReadLine();
            var campers = _context.Campers.Where(c => c.FirstName == firstName).FirstOrDefault();
            if (campers is Camper)
            {
                var camper = _context.Campers.Where(c => c.FirstName == firstName).ToList();
                foreach (var c in camper)
                {
                    Console.WriteLine($"Camper count is {camper.Count} with CamperId {c.CamperId} for {c.FirstName} {c.Surname} Allergies: {c.Allergies}");
                }
            }
            else
            {
                Console.WriteLine("Invalid name");
            }
        }

        public static void ListAllCampers()
        {
            var campers = _context.Campers.ToList();
            Console.WriteLine($"\tTotal number of campers: {campers.Count}");
            foreach (var camper in campers)
            {
                Console.WriteLine($"Name: {camper.FirstName} | Surname: {camper.Surname} | Camper Id: {camper.CamperId}");
            }
        }

        public static void AddCabinCamper()
        {
            Console.WriteLine("\n\n\tEnter cabin Id:");
            int uiCabinId = int.Parse(Console.ReadLine());
            var cabinCamper = _context.CabinCamper.Where(cab => cab.CabinId == uiCabinId).ToList();
            if (cabinCamper.Count >= 4)
            {
                Console.WriteLine($"Cabin Id {uiCabinId} is full");
            }
            else if (cabinCamper.Count < 4)
            {
                var cabinCounselor = _context.CabinCounselor.Where(cabcao => cabcao.CabinId == uiCabinId).ToList();
                if (cabinCounselor.Count == 0)
                {
                    Console.WriteLine($"\tWarning: No counselor is assigned to cabin Id {uiCabinId}");
                }
                Console.WriteLine("Enter camper Id:");
                int uiCamperId = int.Parse(Console.ReadLine());
                DateTime enterDate = DateTime.Today;
                var CabinCamper = new CabinCamper { CabinId = uiCabinId, CamperId = uiCamperId, EnterDate = enterDate };
                _context.CabinCamper.Add(CabinCamper);
                _context.SaveChanges();
                Console.WriteLine($"Camper id {uiCamperId} successfully added to Cabin {uiCabinId}");
            }
        }
    }
}