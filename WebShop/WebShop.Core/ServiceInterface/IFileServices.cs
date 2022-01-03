using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;
using WebShop.Core.Dtos.ProductDto;

namespace WebShop.Core.ServiceInterface
{
    public interface IFileServices : IApplicationService
    { 
        string ProcessUploadedFile(ProductDto dto, Product product);

        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
        Task<ExistingFilePath> RemoveImages(ExistingFilePathDto[] dto);
    }
}
