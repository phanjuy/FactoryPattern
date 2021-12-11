﻿using FactoryPattern.Enums;

namespace FactoryPattern.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public PaymentProvider PaymentProvider { get; set; }
    }
}
