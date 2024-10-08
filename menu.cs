using petBoardingNameSpace;
using utils;

namespace menuNamespace
{
    public static class Menu
    {
        private static int _menuSelection = 0;

        public static void ShowMenuOptions()
        {
            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Check available vacancies");
            Console.WriteLine(" 6. Search for tenants");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or Choose 9 to exit the program)");
        }

        public static void GetMenuSelectionFromUser()
        {
            string? readUserSelection;

            readUserSelection = Utility.getAndSanitizeUserInput();

            _menuSelection = Convert.ToInt32(readUserSelection);

            Console.WriteLine($"you have selected:{_menuSelection}");
        }

        public static async Task ProcessMenuSelection(petBoarding pb)
        {
            while (_menuSelection != 9)
            {
                switch (_menuSelection)
                {
                    case 1:
                        pb.showBoardedAnimals();
                        break;
                    case 2:
                        pb.boardNewAnimals();
                        break;
                    case 3:
                        pb.examineAndSetAgeForAllAnimals();
                        break;
                    case 4:
                        pb.examineAndSetCharacterForAllAnimals();
                        break;
                    case 5:
                        Console.WriteLine($"Current Vacancies: {pb.Vacancies}");
                        break;
                    case 6:
                        await pb.getSearchResults();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Choose from above options to continue or enter \"9\" to exit app");
                string? option;

                option = Utility.getAndSanitizeUserInput();
                _menuSelection = Convert.ToInt32(option);
            }
        }

    }
}