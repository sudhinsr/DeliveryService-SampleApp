﻿using System.Collections.Generic;

namespace DeliveryService.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsGoldenCustomer { get; set; }

        public virtual ICollection<Order> Order { get; set; }

    }
}