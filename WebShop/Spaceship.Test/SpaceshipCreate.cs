using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Dtos;
using WebShop.Core.ServiceInterface;
using Xunit;

namespace Spaceship.Test
{
    public class SpaceshipCreate
    {
        private readonly ISpaceshipService _spaceship;

        public SpaceshipCreate
            (
                ISpaceshipService spaceship
            )
        {
            spaceship = _spaceship;
        }
        [Fact]
        public void When_CreateNewSpaceship_ThenItWillAddNewData()
        {
            var spaceship = new SpaceshipDto
            {
                Name = "Superman",
                Type = "Corvette",
                Mass = 123,
                Price = 123,
                ConstructedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Crew = 123
            };

            var result = _spaceship.Add(spaceship);

            //Assert.Empty(result);
        }
    }
}
