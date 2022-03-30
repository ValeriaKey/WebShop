using System;
using Xunit;

namespace HouseTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Should_AddNewSpaceship_WhenReturnResult()
        {
            string guid = "a1925975-d8fc-4f55-b614-d9b5aa7b4ebe";
            //byte[] array1 = new byte[1000 * 1000 * 3];

            HouseDto house = new HousedDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "Space";
            spaceship.Type = "Estonia";
            spaceship.Price = 123;
            spaceship.Crew = 123;
            spaceship.Mass = 123;
            spaceship.ConstructedAt = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipService>().Add(spaceship);

            Assert.NotNull(result);
        }
    }
}
