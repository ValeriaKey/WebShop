using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;
using WebShop.Core.Dtos.CarDto;

namespace WebShop.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<Car> Delete(Guid id);
        Task<Car> Add(CarDto dto);

        Task<Car> Edit(Guid id);

        Task<Car> Update(CarDto dto);

        Task<ExistingFilePathForCar> RemoveImage(ExistingFilePathForCarDto dto);
    }
}
