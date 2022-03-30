using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;

namespace WebShop.Core.ServiceInterface
{
    public interface IHouseService
    {
        Task<House> Delete(Guid id);
        Task<House> Add(HouseDto dto);
        Task<House> Edit(Guid id);
        Task<House> Update(HouseDto dto);

        // FOR TEST
        Task<House> GetAsync(Guid id);

    }
}
