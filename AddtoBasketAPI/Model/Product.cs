using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddtoBasketAPI.Model
{
    public class Product : BaseEntityModel
    {
        public string Title { get; set; }

        public string Brand { get; set; }

        public int PricePerUnit { get; set; }

        public int Total { get; set; }
    }
}
