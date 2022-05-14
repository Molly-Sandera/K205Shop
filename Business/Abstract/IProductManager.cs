using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    {
        List<Product> GetProduct();
        List<ProductDTO> GetAllProductList();
        void AddProduct(AddProductDTO product);
        void Remove(Product product);
        void Update(UpdateProductDTO product);   
        ProductDTO GetProductById(int id);

    }
}
