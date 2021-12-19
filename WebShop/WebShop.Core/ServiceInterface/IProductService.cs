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
    public interface IProductService
    {
        Task<Product> Delete(Guid id);

        Task<Product> Add(ProductDto dto);

        Task<Product> Edit(Guid id);

        Task<Product> Update(ProductDto dto);
    }
}
