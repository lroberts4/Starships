using System;
using StarWarsApiCSharp;

namespace StarShips
{
    public class Voyage
    {
        #region Private variables

        private int _consumerablesPerHour;

        private static int _hoursPerDay = 24;
        private static int _hoursPerWeek = 7 * _hoursPerDay;
        private static int _hoursPerMonth = 4 * _hoursPerWeek;
        private static int _hoursPerYear = 12 * _hoursPerMonth;

        #endregion

        public Voyage(Starship starship)
        {
            Starship = starship;
        }

        /// <summary>
        /// Starship instance which we are calculating
        /// the voyage information for
        /// </summary>
        private Starship Starship { get; set; }

        /// <summary>
        /// Calculates the consumerables burned per
        /// hour based on the consumerables for this starship
        /// instance.
        /// </summary>
        private int ConsumerablesPerHour
        {
            get
            {
                // split the consumerables value into the value and the kind (days, weeks, months, years)
                var consumerables = Starship.Consumables.Split(' ');

                // amount of the given value (days, weeks, months, years) we need to multiply by 
                var amountOfGivenValue = Convert.ToInt32(consumerables[0]);

                // given the kind of value we retrieved, find the number of consumerables used per hour
                switch (consumerables[1])
                {
                    case "day":
                    case "days":
                        _consumerablesPerHour = amountOfGivenValue * _hoursPerDay;
                        break;
                    case "week":
                    case "weeks":
                        _consumerablesPerHour = amountOfGivenValue * _hoursPerWeek;
                        break;
                    case "month":
                    case "months":
                        _consumerablesPerHour = amountOfGivenValue * _hoursPerMonth;
                        break;
                    case "year":
                    case "years":
                        _consumerablesPerHour = amountOfGivenValue * _hoursPerYear;
                        break;
                    default:
                        _consumerablesPerHour = 0;
                        break;
                }

                return _consumerablesPerHour;
            }
        }

        /// <summary>
        /// MGLT (distance they can travel per hour)
        /// multiplied by the amount consumed per hour
        /// </summary>
        public int DistanceTillRefuel => Convert.ToInt32(Starship.MegaLights) * ConsumerablesPerHour;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distanceToTravel"></param>
        /// <returns></returns>
        public int CalculateNumberOfStopsForStarship(int distanceToTravel)
        {
            if (DistanceTillRefuel == 0)
                return 0;

            return distanceToTravel / DistanceTillRefuel;
        }
    }
}
