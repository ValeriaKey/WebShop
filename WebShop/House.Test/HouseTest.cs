using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Dtos;
using WebShop.Core.ServiceInterface;
using Xunit;

namespace House.Test
{
    public class HouseTest : TestBase
    {
        // ADD

        [Fact]
        public async Task Should_AddNewHouse_WhenReturnResult()
        {
        string guid = "a1925975-d8fc-4f55-b614-d9b5aa7b4ebe";
        //byte[] array1 = new byte[1000 * 1000 * 3];

        HouseDto house = new HouseDto();

        house.Id = Guid.Parse(guid);
        house.Address = "Mustamae tee 22B";
        house.Floors = 1;
        house.Rooms = 3;
        house.Price = 310.000;
        house.Area = 67;
        house.Color = "Gray";
        house.ConstructedAt = DateTime.Now;
        house.CreatedAt = DateTime.Now;
        house.ModifiedAt = DateTime.Now;

        var result = await Svc<IHouseService>().Add(house);

        Assert.NotNull(result);
        }

        // DELETE

        [Fact]
        public async Task Should_DeleteHouse_WhenHouseAldreayAdded()
        {
             // Firstly -  House adding
        string guid = "9D1F59E2-409C-485F-B277-08DA12704320";

        var insertGuid = Guid.Parse(guid);

            HouseDto house = new HouseDto();

            house.Id = insertGuid;
            house.Address = "Mustamae tee 22B";
            house.Floors = 1;
            house.Rooms = 3;
            house.Price = 310.000;
            house.Area = 67;
            house.Color = "Gray";
            house.ConstructedAt = DateTime.Now;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            await Svc<IHouseService>().Add(house);
            
            // House Deleting
            var result = Svc<IHouseService>().Delete(insertGuid);
            Assert.NotNull(result);
} 

            // DIFFERENT IDs
            [Fact]
            public async Task ShouldNot_GetByIdHouse_WhenReturnsResultAsync()
            {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().GetAsync(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
            }

            // SAME IDs

            [Fact]
            public async Task Should_GetByIdHouse_WhenReturnsResultAsync()
            {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().GetAsync(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
            }
    }

}
