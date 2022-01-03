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
    public interface IFileServices : IApplicationService
    {
        string ProcessUploadedFile(CarDto dto, Car car);
        Task<ExistingFilePathForCar> RemoveImage(ExistingFilePathForCarDto dto);
        Task<ExistingFilePathForCar> RemoveImages(ExistingFilePathForCarDto[] dto);
    }
}
