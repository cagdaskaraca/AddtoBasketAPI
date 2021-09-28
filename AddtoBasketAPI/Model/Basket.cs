using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddtoBasketAPI.Model
{
    public class Basket : BaseEntityModel
    {
        public int ProductId { get; set; }

        public Guid UserId { get; set; }

        public List<Product> Product { get; set; } = new List<Product>();
    }
}
