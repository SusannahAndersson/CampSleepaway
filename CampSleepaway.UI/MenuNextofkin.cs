using CampSleepaway.Data;
using CampSleepaway.Domain;

namespace CampSleepaway.UI
{
    public class MenuNextofkin
    {
        public static CampSleepawayContext _context = new CampSleepawayContext();

        public static void AddNextofkin()
        {
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            //Console.WriteLine("Social security number: ");
            //string ssn = Console.ReadLine();
            //Console.WriteLine("Phone number: ");
            //string phone = Console.ReadLine();
            var nextOfKin = new NextOfKin
            {
                FirstName = firstName,
                Surname = surname /*, SocialSecurityNumber = ssn, Phone = phone*/
            };
            _context.NextOfKins.Add(nextOfKin);
            _context.SaveChanges();
            Console.WriteLine($"[ {firstName} ] successfully added");
        }

        public static void DeletNextofkin()
        {
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            var nextofkin = _context.NextOfKins.Where(c => c.FirstName == firstName).FirstOrDefault();
            _context.NextOfKins.Remove(nextofkin);
            _context.SaveChanges();
            Console.WriteLine($"[ {firstName} ] successfully deleted");
        }

        public static void UpdateNextofkin()
        {
            Console.WriteLine("Enter next of kin current/old surname:");
            string surname = Console.ReadLine();
            var nextofkins = _context.NextOfKins.Where(c => c.Surname == surname).FirstOrDefault();
            if (nextofkins is NextOfKin)
            {
                Console.WriteLine("Enter next of kins new surname:");
                string newSurname = Console.ReadLine();
                nextofkins.Surname = newSurname;
                _context.SaveChanges();
                Console.WriteLine($"[ {newSurname} ] successfully updated");
            }
            else
            {
                Console.WriteLine("Invalid current/old surname");
            }
        }

        public static void ListAllNextOfKin()
        {
            var nextofkins = _context.NextOfKins.ToList();
            Console.WriteLine($"\tNumber of next of kin: {nextofkins.Count}");
            foreach (var nextofkin in nextofkins)
            {
                Console.WriteLine($"Name: {nextofkin.FirstName} | Surname: {nextofkin.Surname} | Next of kin Id: {nextofkin.NextOfKinId}");
            }
        }
    }
}