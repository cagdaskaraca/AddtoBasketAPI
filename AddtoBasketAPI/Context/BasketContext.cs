using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddtoBasketAPI.Extensions;
using AddtoBasketAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AddtoBasketAPI.Extensions
{
    public class BasketContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public BasketContext(DbContextOptions<BasketContext> options)
            : base(options)
        {
        }

    }
}
