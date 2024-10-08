using AnimalNameSpace;
using utils;

namespace petBoardingNameSpace
{
    public class petBoarding
    {
        private int _maxPets;
        private int _vacancies;
        private readonly List<Animal> _boardedAnimals = [];
        public Animal[] BoardedAnimals { get => [.. _boardedAnimals]; }

        public int Vacancies { get => _vacancies; }

        public petBoarding(int maxPetCount)
        {
            maxPets = maxPetCount;
            _vacancies = maxPetCount;

        }

        public int maxPets
        {
            get => _maxPets;
            set => _maxPets = value;
        }




        public void setInitialValues()
        {
            string[,] dataRandomizer = new string[3, 4] { { "bruno", "Collie", "Hari", "25.908080880" }, { "Simbi", "Indie", "Shakthi", "68.00" }, { "Bhairee", "dog?", "Uttara", "45.90" } };
            Random r = new Random();
            for (int i = 0; i < 3; i++)
            {
                int outerIndex = r.Next(0, 3);
                string animalName = dataRandomizer[outerIndex, 0];
                string animalBreed = dataRandomizer[outerIndex, 1];
                string animalOwner = dataRandomizer[outerIndex, 2];
                string donation = dataRandomizer[outerIndex, 3];

                Animal a = new Animal();

                a.setInitialAnimalDetails(animalName, animalBreed, animalOwner, donation);
                _boardedAnimals.Add(a);
                _vacancies -= 1;
            }
        }

        public bool checkVacancies()
        {
            return _vacancies > 0;
        }

        public void addPet(string name, string breed, string owner, string donation)
        {

            Animal newAnimal = new Animal();
            newAnimal.setInitialAnimalDetails(name, breed, owner, donation);
            _boardedAnimals.Add(newAnimal);
            _vacancies -= 1;
            Console.WriteLine("Successfully boarded your pet!");
        }

        public void showBoardedAnimals()
        {
            foreach (Animal a in _boardedAnimals)
            {
                a.PrintDetails();
            }
        }

        public void boardNewAnimals()
        {
            if (!checkVacancies())
            {
                Console.WriteLine("Sorry fully boarded, Pls try again later!");
            }
            else
            {
                string? addMore = "y";
                while (checkVacancies() && addMore.ToLower() == "y")
                {
                    string petName;
                    string petBreed;
                    string petOwner;
                    string suggestedDonation;

                    Console.WriteLine("Enter pet name");
                    petName = Utility.getAndSanitizeUserInput().ToLower();

                    Console.WriteLine("Enter pet breed");
                    petBreed = Utility.getAndSanitizeUserInput().ToLower();

                    Console.WriteLine("Enter pet owner");
                    petOwner = Utility.getAndSanitizeUserInput().ToLower();

                    Console.WriteLine("Enter suggested donation");
                    suggestedDonation = Utility.getAndSanitizeUserInput().ToLower();

                    addPet(petName, petBreed, petOwner, suggestedDonation);

                    if (checkVacancies())
                    {
                        Console.WriteLine($"We have space for {_vacancies} more animals, Would you like to add more animals ?");
                        addMore = Utility.getAndSanitizeUserInput().ToLower();
                    }
                }
            }

        }

        public void examineAndSetCharacterForAllAnimals()
        {
            foreach (Animal a in _boardedAnimals)
            {
                string? character;
                Console.WriteLine($"Enter the character for {a.AnimalName}");
                character = Utility.getAndSanitizeUserInput().ToLower();
                a.setAnimalCharacter(character);
            }
        }

        public void examineAndSetAgeForAllAnimals()
        {
            foreach (Animal a in _boardedAnimals)
            {
                string? age;
                Console.WriteLine($"Enter the age for {a.AnimalName}");
                age = Utility.getAndSanitizeUserInput();
                a.setAnimalAge(age);
            }
        }

        private async Task<List<Animal>> getSearchResultsForAnimals(List<string> searchTerms)
        {

            List<Animal> filteredAnimals = [];
            searchTerms.ForEach(st =>
            {
                _boardedAnimals.ForEach(ba =>
                {
                    if (ba.AnimalBreed != null && ba.AnimalBreed.Contains(st, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (!filteredAnimals.Contains(ba))
                        {
                            filteredAnimals.Add(ba);
                        }
                    }
                });
            });

            await Task.Delay(5000);

            return filteredAnimals;
        }

        public async Task getSearchResults()
        {

            string breed;
            List<string> searchTerms;
            List<Animal> filteredAnimals = [];

            string[] searchDots = [".", "..", "..."];

            Console.WriteLine($"Enter the characteristics to search for, seperated by commas:");
            breed = Utility.getAndSanitizeUserInput();

            searchTerms = breed.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList<string>();

            for (int i = 0; i < searchTerms.Count; i++)
            {
                searchTerms[i] = searchTerms[i].Trim();
            }

            var resultsAsync = getSearchResultsForAnimals(searchTerms);
            Console.Write("Searching for your dog ");

            while (!resultsAsync.IsCompletedSuccessfully)
            {

                for (int i = 0; i < searchDots.Length; i++)
                {
                    Console.SetCursorPosition(25, Console.CursorTop);
                    Console.Write($" {searchDots[i]}");
                    Thread.Sleep(500);
                }

            }

            Console.WriteLine("\n");

            filteredAnimals = await resultsAsync;


            if (filteredAnimals.Count > 0)
            {
                filteredAnimals.ForEach(fa => fa.PrintDetails());

            }
            else
            {
                Console.WriteLine("Ooops, no such breed found");
            }
        }
    }
}