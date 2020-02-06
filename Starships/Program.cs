using System;
using StarShips;
using StarWarsApiCSharp;

namespace Starships
{
    class MainClass
    {
        private static readonly string Stars = "\n***************************************\n";

        public static void Main(string[] args)
        {
            Console.WriteLine(Stars);
            Console.WriteLine("Welcome to your one stop shop for Starships!");
            Console.WriteLine(Stars);

            var result = "Y";
            while (result == "Y")
            {
                var distance = GetDistanceFromUser();

                Console.WriteLine(Stars);

                Console.WriteLine("Below is the number of stops each starship will make: ");

                PrintStarships(distance);

                Console.WriteLine(Stars);

                result = AskUserToContinue();
            }

            
        }

        /// <summary>
        /// Get the distance from the user
        /// </summary>
        /// <returns>Given distance the user has requested</returns>
        public static int GetDistanceFromUser()
        {
            int distance;

            Console.WriteLine("Please enter the distance you want to travel: ");

            int.TryParse(Console.ReadLine(), out distance);

            return distance;
        }

        public static void PrintStarships(int distanceToTravel)
        {
            // Create a new instance of the starships repository
            IRepository<Starship> starshipRepo = new Repository<Starship>();

            // Get all the pages of the starships entities
            var starships = starshipRepo.GetEntities(1, 10);

            // For each of the given starships get the number of stops and print to the console
            foreach (var starship in starships)
            {
                var voyage = new Voyage(starship);

                Console.WriteLine(starship.Name + ": "
                    + voyage.CalculateNumberOfStopsForStarship(distanceToTravel)
                    + " stops.");
            }
        }

        /// <summary>
        /// Asked the user if they want to continue entering input
        /// </summary>
        /// <returns>Y or N depending on the user input to continue</returns>
        public static string AskUserToContinue()
        {
            var repeat = true;
            string answer = string.Empty;

            while (repeat)
            {
                Console.WriteLine("Would you like to continue(Y/N)?");

                answer = Console.ReadLine().ToUpper();

                if (answer == "Y" || answer == "N")
                    repeat = false;
            }

            return answer;
        }
    }
}
