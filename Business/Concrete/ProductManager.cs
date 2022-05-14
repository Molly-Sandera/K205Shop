using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProduct(AddProductDTO productDTO)
        {
            Product product = new()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                CategoryId = productDTO.CategoryId,
                Price = productDTO.Price,
                SKU = productDTO.SKU,
                Summary = productDTO.Summary,
            };
            _productDal.Add(product);
        }

        public List<ProductDTO> GetAllProductList()
        {
            return _productDal.GetAllProducts();
        }

        public List<Product> GetProduct()
        {
            return _productDal.GetAll();
        }

        public ProductDTO GetProductById(int id)
        {
            return _productDal.FindById(id);
        }

        public void Remove(Product product)
        {
            _productDal.Delete(product);
        }

        public void Update(UpdateProductDTO productDTO)
        {
            //_productDal.Update(productDTO);
        }

       
    }
}
