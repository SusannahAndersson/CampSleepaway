using CampSleepaway.Data;
using CampSleepaway.Domain;

namespace CampSleepaway.UI
{
    public class MenuCabin
    {
        public static CampSleepawayContext _context = new CampSleepawayContext();

        public static void AddCabin()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            var cabin = new Cabin { Name = name };
            _context.Cabins.Add(cabin);
            _context.SaveChanges();
            Console.WriteLine($"Cabin: [{name}] successfully added");
        }

        public static void DeleteCabin()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            var cabin = _context.Cabins.Where(c => c.Name == name).FirstOrDefault();
            _context.Cabins.Remove(cabin);
            _context.SaveChanges();
            Console.WriteLine($"Cabin: [{name}] successfully deleted");
        }

        public static void UpdateCabin()
        {
            Console.WriteLine("Cabins current/old name:");
            string name = Console.ReadLine();
            var cabin = _context.Cabins.Where(c => c.Name == name).FirstOrDefault();
            if (cabin is Cabin)
            {
                Console.WriteLine("Cabins new name:");
                string newName = Console.ReadLine();
                cabin.Name = newName;
                _context.SaveChanges();
                Console.WriteLine($"Cabin: [{newName}] successfully updated");
            }
            else
            {
                Console.WriteLine("Invalid current/old name");
            }
        }

        public static void ListAllCabins()
        {
            var cabins = _context.Cabins.ToList();
            Console.WriteLine($"\tNumber of cabins: {cabins.Count}");
            foreach (var cabin in cabins)
            {
                Console.WriteLine($"Cabin Name: {cabin.Name} | Cabin Id: {cabin.CabinId}");
            }
        }

        public static void SearchCabinsCampers()
        {
            Console.WriteLine("Enter cabin Id to display camper visits by cabin:");
            int uiCabinId = int.Parse(Console.ReadLine());
            var entityCabinCamper = from cam in _context.Campers
                                    join cabcam in _context.CabinCamper
                                    on cam.CamperId equals cabcam.CamperId
                                    join cab in _context.Cabins
                                    on cabcam.CabinId equals cab.CabinId
                                    where cab.CabinId == uiCabinId
                                    select new
                                    {
                                        cab.CabinId,
                                        cab.Name,
                                        cam.CamperId,
                                        cam.FirstName,
                                        cam.Surname,
                                        cabcam.EnterDate,
                                        cabcam.ExitDate
                                    };
            var cabinCounselor = _context.CabinCounselor.Where(cab => cab.CabinId == uiCabinId).ToList();
            if (cabinCounselor.Count == 0)
            {
                Console.WriteLine($"\tWarning: No counselor is assigned to cabin Id {uiCabinId}");
            }
            foreach (var cabinCamper in entityCabinCamper)
            {
                Console.WriteLine($"Cabin Id: {cabinCamper.CabinId} | Cabin Name: {cabinCamper.Name}" +
                    $"\nCamper Id: {cabinCamper.CamperId} | Name: {cabinCamper.FirstName} {cabinCamper.Surname}" +
                    $"\nEnter date: {cabinCamper.EnterDate} | Exit date: {cabinCamper.ExitDate}");
            }
        }

        public static void SearchCabinsNextofkins()
        {
            Console.WriteLine("Enter cabin Id to display next of kin visits by cabin:");
            int uiCabinId = int.Parse(Console.ReadLine());
            var entityCamperNextofkin = from nok in _context.NextOfKins
                                        join camnok in _context.CamperNextOfKin
                                        on nok.NextOfKinId equals camnok.NextOfKinId
                                        join cam in _context.Campers
                                        on camnok.CamperId equals cam.CamperId
                                        join cabcam in _context.CabinCamper
                                        on cam.CamperId equals cabcam.CamperId
                                        join cab in _context.Cabins
                                        on cabcam.CabinId equals cab.CabinId
                                        where cab.CabinId == uiCabinId
                                        select new
                                        {
                                            cab.CabinId,
                                            cab.Name,
                                            cam.CamperId,
                                            cam.FirstName,
                                            cam.Surname,
                                            nok.NextOfKinId,
                                            nok.nokFullName,
                                            camnok.EnterDate,
                                            camnok.ExitDate,
                                        };
            if (entityCamperNextofkin.ToList().Count == 0)
            {
                Console.WriteLine($"\tNo next of kin to camper found by cabin Id {uiCabinId}");
            }
            else
            {
                foreach (var nextofkinCamper in entityCamperNextofkin)
                {
                    Console.WriteLine($"\tCabin id: {nextofkinCamper.CabinId} | Cabin name: {nextofkinCamper.Name}" +
                        $"\nCamper Id: {nextofkinCamper.CamperId} | Name: {nextofkinCamper.FirstName} {nextofkinCamper.Surname}" +
                        $"\nNextofkin Id: {nextofkinCamper.NextOfKinId} | Name: {nextofkinCamper.nokFullName}" +
                        $"\nEnter date: {nextofkinCamper.EnterDate} | Exitdate: {nextofkinCamper.ExitDate}");
                }
            }
        }
    }
}