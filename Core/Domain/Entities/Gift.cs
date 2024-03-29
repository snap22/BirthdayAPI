﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Entities
{
    public class Gift
    {
        public int GiftId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double EstimatedPrice { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
