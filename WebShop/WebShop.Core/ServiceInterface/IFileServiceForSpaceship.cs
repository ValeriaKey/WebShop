using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;

namespace WebShop.Core.ServiceInterface
{
    public interface IFileServiceForSpaceship : IApplicationServiceForSpaceship
    {
        string ProcessUploadedFile(SpaceshipDto dto, Spaceship spaceship);
        Task<ExistingFilePathForSpaceship> RemoveImage(ExistingFilePathForSpaceshipDto dto);
        Task<ExistingFilePathForSpaceship> RemoveImages(ExistingFilePathForSpaceshipDto[] dto);
    }
}
