using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;

namespace WebShop.Core.ServiceInterface
{
    public interface IProductService
    {
        Task<Product> Delete(Guid id);
    }
}
