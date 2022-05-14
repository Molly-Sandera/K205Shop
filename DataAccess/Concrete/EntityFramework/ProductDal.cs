using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EfEntityRepositoryBase<Product, ShopDbContext>, IProductDal
    {
        public ProductDTO FindById(int id)
        {
            using (ShopDbContext context = new())
            {
                var product = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
                var productPictures = context.ProductPicture.Where(x => x.ProductId == id).ToList();
                List<string> pictures = new();

                foreach (var picture in productPictures)
                {
                    pictures.Add(picture.PhotoURL);
                }
                ProductDTO result = new()
                {
                    id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryName = product.Category.Name,
                    Price = product.Price,
                    SKU = product.SKU,
                    Summary = product.Summary,
                    ProductPicture = pictures,
                    CoverPhoto = product.CoverPhoto,
                    IsSlider = product.IsSlider,
                };

                return result;
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            using (ShopDbContext context = new())
            {
                var products = context.Products.Include(x => x.Category).Include(x => x.ProductPicture).ToList();
                var productPictures = context.ProductPicture;
                List<ProductDTO> result = new();

                for (int i = 0; i < products.Count; i++)
                {
                    List<string> pictures = new();
                    foreach (var item in productPictures.Where(x => x.ProductId == products[i].Id))
                    {
                        pictures.Add(item.PhotoURL);
                    }

                    ProductDTO productList = new()
                    {
                        id = products[i].Id,
                        Name = products[i].Name,
                        Description = products[i].Description,
                        CategoryName = products[i].Category.Name,
                        Price = products[i].Price,
                        SKU = products[i].SKU,
                        Summary = products[i].Summary,
                        ProductPicture = pictures,
                        CoverPhoto = products[i].CoverPhoto,
                        IsSlider = products[i].IsSlider,
                    };
                    result.Add(productList);
                }


                return result;
            }
        }
    }
}
