using System.Reflection.Metadata.Ecma335;

namespace AnimalNameSpace
{
    public class Animal
    {

        public string? AnimalName;
        public string? AnimalBreed;
        public string? AnimalOwner;

        public string? AnimalAge;

        public string? AnimalCharacter;

        private decimal _donation;

        public string SuggestedDonation
        {
            get { return $"{_donation:C2}"; }
            set
            {

                if (!Decimal.TryParse(value, out _donation))
                {
                    _donation = 45.00m;
                }

            }
        }

        public void setInitialAnimalDetails(string name, string breed, string owner, string suggestedDonation)
        {
            AnimalName = name;
            AnimalBreed = breed;
            AnimalOwner = owner;
            SuggestedDonation = suggestedDonation;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"petName: {AnimalName}");
            Console.WriteLine($"petBreed: {AnimalBreed}");
            Console.WriteLine($"petOwner: {AnimalOwner}");
            Console.WriteLine($"SuggestedDonation: {SuggestedDonation}");

            if (!String.IsNullOrEmpty(AnimalAge))
            {
                Console.WriteLine($"petAge: {AnimalAge}");
            }

            if (!String.IsNullOrEmpty(AnimalCharacter))
            {
                Console.WriteLine($"petCharacter: {AnimalCharacter}");
            }
        }

        public void setAnimalAge(string age)
        {
            AnimalAge = age;
        }

        public void setAnimalCharacter(string character)
        {
            AnimalCharacter = character;
        }
    }

}
