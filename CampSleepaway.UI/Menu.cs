using CampSleepaway.Data;
using Figgle;

namespace CampSleepaway.UI
{
    public class Menu
    {
        public static CampSleepawayContext context = new CampSleepawayContext();

        public void MainMenu()
        {
            bool stopLoop = false;
            Console.WriteLine(
                FiggleFonts.Ogre.Render("Camp Sleepaway") +
                    "\tMake a choice to modify:\n\n" +
                    "(1) Campers\n" +
                    "(2) Counselors\n" +
                    "(3) Next of kins\n" +
                    "(4) Cabins\n" +
                    "(5) Exit");
            do
            {
                string userInputMainMenu = Console.ReadLine();
                int.TryParse(userInputMainMenu, out int mainMenuChoice);
                switch (mainMenuChoice)
                {
                    case 1:
                        CampersMenu();
                        break;

                    case 2:
                        CounselorsMenu();
                        break;

                    case 3:
                        NextOfKinsMenu();
                        break;

                    case 4:
                        CabinsMenu();
                        break;

                    case 5:
                        stopLoop = true;
                        break;

                    default:
                        Console.WriteLine($"Incorrect value. Try again\n");
                        break;
                }
            } while (!stopLoop);
        }

        public void CampersMenu()
        {
            Console.WriteLine(
              "(1) Add new camper\n" +
                    "(2) Delete camper\n" +
                    "(3) Update camper\n" +
                    "(4) Search camper\n" +
                    "(5) List all campers\n" +
                    "(6) Add camper to cabin\n" +
                    "(7) Exit");
            int campersMenu = int.Parse(Console.ReadLine());
            switch (campersMenu)
            {
                case 1:

                    MenuCamper.AddCamper();
                    break;

                case 2:
                    MenuCamper.DeleteCamper();
                    break;

                case 3:
                    MenuCamper.UpdateCamper();
                    break;

                case 4:
                    MenuCamper.SearchCamper();
                    break;

                case 5:
                    MenuCamper.ListAllCampers();
                    break;

                case 6:
                    MenuCabin.ListAllCabins();
                    MenuCamper.AddCabinCamper();
                    break;

                case 7:
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Incorrect value. Try again\n");
                    break;
            }
        }

        public void CounselorsMenu()
        {
            Console.WriteLine(
                "(1) Add new counselor\n" +
                    "(2) Delete counselor\n" +
                    "(3) Update counselor\n" +
                    "(4) Search counselor\n" +
                    "(5) List all counselor\n" +
                    "(6) Add counselor to cabin\n" +
                    "(7) Exit");
            int counselorsMenu = int.Parse(Console.ReadLine());
            switch (counselorsMenu)
            {
                case 1:
                    MenuCounselor.AddCounselor();
                    break;

                case 2:
                    MenuCounselor.DeleteCounselor();
                    break;

                case 3:
                    MenuCounselor.UpdateCounselor();
                    break;

                case 4:
                    MenuCounselor.SearchCounselor();
                    break;

                case 5:
                    MenuCounselor.ListAllCounselors();
                    break;

                case 6:
                    MenuCabin.ListAllCabins();
                    MenuCounselor.AddCabinCounselor();
                    break;

                case 7:
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Incorrect value. Try again\n");
                    break;
            }
        }

        public void CabinsMenu()
        {
            Console.WriteLine(
              "(1) Add new cabin\n" +
                    "(2) Delete cabin\n" +
                    "(3) Update cabin\n" +
                    "(4) List all cabins\n" +
                    "(5) List campers by cabin\n" +
                    "(6) List campers nextofkin by cabin\n" +
                    "(7) Exit");
            int cabinsMenu = int.Parse(Console.ReadLine());
            switch (cabinsMenu)
            {
                case 1:
                    MenuCabin.AddCabin();
                    break;

                case 2:
                    MenuCabin.DeleteCabin();
                    break;

                case 3:
                    MenuCabin.UpdateCabin();
                    break;

                case 4:
                    MenuCabin.ListAllCabins();
                    break;

                case 5:
                    MenuCabin.SearchCabinsCampers();
                    break;

                case 6:
                    MenuCabin.SearchCabinsNextofkins();
                    break;

                case 7:
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("\n\tIncorrect value. Try again\n");
                    break;
            }
        }

        public void NextOfKinsMenu()
        {
            Console.WriteLine(
                "(1) Add new next of kin\n" +
                    "(2) Delete next of kin\n" +
                    "(3) Update next of kin\n" +
                    "(4) List all next of kin\n" +
                    "(5) Exit");
            int nextOfKinMenu = int.Parse(Console.ReadLine());
            switch (nextOfKinMenu)
            {
                case 1:
                    MenuNextofkin.AddNextofkin();
                    break;

                case 2:
                    MenuNextofkin.DeletNextofkin();
                    break;

                case 3:
                    MenuNextofkin.UpdateNextofkin();
                    break;

                case 4:
                    MenuNextofkin.ListAllNextOfKin();
                    break;

                case 5:
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Incorrect value. Try again\n");
                    break;
            }
        }
    }
}