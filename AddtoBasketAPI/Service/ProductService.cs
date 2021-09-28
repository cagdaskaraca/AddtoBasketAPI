using AddtoBasketAPI.Extensions;
using AddtoBasketAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddtoBasketAPI.Service
{
    public class ProductService
    {
        private readonly BasketContext _basketContext;

        public ProductService(BasketContext basketContext)
        {
            _basketContext = basketContext;

            if (basketContext.Products.Count() == 0)
            {
                _basketContext.Products.Add(new Product { Brand = "Çiçek", PricePerUnit = 20, Title = "Orkide" });
                _basketContext.Products.Add(new Product { Brand = "Hediye", PricePerUnit = 20, Title = "Peluş Oyuncak" });
                _basketContext.Products.Add(new Product { Brand = "Yenilebilir Çiçek", PricePerUnit = 20, Title = "Çikolatalı çilek" });
                _basketContext.Products.Add(new Product { Brand = "Ev Yaşam", PricePerUnit = 20, Title = "Yastık" });
                _basketContext.Products.Add(new Product { Brand = "Takı, Saat", PricePerUnit = 20, Title = "Yüzük" });
                _basketContext.Products.Add(new Product { Brand = "Elektronik", PricePerUnit = 20, Title = "Kulaklık" });
                _basketContext.Products.Add(new Product { Brand = "Parfüm, Kişisel Bakım", PricePerUnit = 20, Title = "El kremi" });
                _basketContext.Products.Add(new Product { Brand = "Moda", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Spor", PricePerUnit = 20, Title = "Yoga Matı" });

                _basketContext.SaveChanges();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return _basketContext.Products.ToList();
        }

        public async Task<Product> Get(int id)
        {
            return await _basketContext.Products.FindAsync(id);
        }
    }
}
