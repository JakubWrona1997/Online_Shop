﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
    class Stock
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product{ get; set; }


    }
}
