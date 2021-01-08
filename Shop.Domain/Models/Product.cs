﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set;  }

        public ICollection<Stock> Stock { get; set; }
    }
}
