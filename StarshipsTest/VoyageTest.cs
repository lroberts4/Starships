using NUnit.Framework;
using StarWarsApiCSharp;
using StarShips;
using System;

namespace StarshipsTest
{
    [TestFixture()]
    public class VoyageTest
    {
        #region DistanceTillRefuel

        [Test()]
        public void Voyage_DistanceTillRefuel_AppropriateConsumerablesGiven_ValueReturned()
        {
            // Arrange
            var starshipA = new Starship()
            {
                Consumables = "1 month",
                MegaLights = "65"
            };

            var starshipB = new Starship()
            {
                Consumables = "3 days",
                MegaLights = "40"
            };

            // Act
            var voyageA = new Voyage(starshipA);
            var voyageB = new Voyage(starshipB);

            // Assert
            Assert.AreEqual(43680, voyageA.DistanceTillRefuel);
            Assert.AreEqual(2880, voyageB.DistanceTillRefuel);
        }

        [Test()]
        public void Voyage_DistanceTillRefuel_GivenUnknownConsumerables_ZeroReturned()
        {
            // Arrange
            var starship = new Starship()
            {
                Consumables = "1 unknown",
            };

            // Act
            var voyage = new Voyage(starship);

            // Assert
            Assert.AreEqual(0, voyage.DistanceTillRefuel);
        }

        #endregion

        #region DistanceTillRefuelIsZero

        [Test()]
        public void Voyage_CalculateNumberOfStopsForStarship_DistanceTillRefuelIsZero_ZeroReturned()
        {
            // Arrange
            var distanceToTravel = 10000;

            var starship = new Starship()
            {
                Consumables = "1 unknown",
                MegaLights = "40"
            };

            // Act
            var voyage = new Voyage(starship);

            // Assert
            Assert.AreEqual(0, voyage.CalculateNumberOfStopsForStarship(distanceToTravel));
        }

        [Test()]
        public void Voyage_CalculateNumberOfStopsForStarship_DistanceTillRefuelHasValue_NumberOfStopsReturned()
        {
            // Arrange
            var distanceToTravel = 1000000;

            var starshipA = new Starship()
            {
                Consumables = "1 year",
                MegaLights = "75"
            };

            var starshipB = new Starship()
            {
                Consumables = "8 weeks",
                MegaLights = "50"
            };

            // Act
            var voyageA = new Voyage(starshipA);
            var voyageB = new Voyage(starshipB);

            // Assert
            Assert.AreEqual(1, voyageA.CalculateNumberOfStopsForStarship(distanceToTravel));
            Assert.AreEqual(14, voyageB.CalculateNumberOfStopsForStarship(distanceToTravel));
        }

        #endregion
    }
}
