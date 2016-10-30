using System.Collections.Generic;
using System.Linq;
using WCApp.Core.Model;

namespace WCApp.Core.Repository
{
    public class ProductRepository
    {
        public Product GetProductById(int id)
        {
            var products = from category in Categories
                from product in category.Products
                where product.Id == id
                select product;

            return products.FirstOrDefault();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            var category = Categories.FirstOrDefault(c => c.Id == id);
            return category?.Products;
        }

        public List<Product> GetOfferProducts()
        {
            var products = from category in Categories
                from product in category.Products
                where product.ShowInOffer
                select product;

            return products.ToList();
        }

        private const string TemplateImgUrl = "https://scontent-mia1-1.xx.fbcdn.net/v/t1.0-9/993740_241660805991754_1248725149_n.png?oh=9fa27cbe705e7877f7681d51424b151b&oe=58D059D3";

        //TODO: Retrieve this from an API
        private static readonly List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = 1, Name = "Electronics", Products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "TV 32",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImgUrl = TemplateImgUrl,
                        Price = 23000,
                        ShowInOffer = true
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Radio",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImgUrl = TemplateImgUrl,
                        Price = 5000,
                        ShowInOffer = false
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "TV 54",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImgUrl = TemplateImgUrl,
                        Price = 50000,
                        ShowInOffer = true
                    }
                }
            },
            new Category
            {
                Id = 2, Name = "Furniture", Products = new List<Product>
                {
                    new Product
                    {
                        Id = 4,
                        Name = "Mini L",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImgUrl = TemplateImgUrl,
                        Price = 15000,
                        ShowInOffer = false
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Juego de habitación",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImgUrl = TemplateImgUrl,
                        Price = 65000,
                        ShowInOffer = true
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Comedor 6 sillas",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImgUrl = TemplateImgUrl,
                        Price = 35000,
                        ShowInOffer = false
                    }
                }
            }
        };
    }
}
