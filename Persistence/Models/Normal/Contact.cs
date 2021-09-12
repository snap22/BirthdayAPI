﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Models.Normal
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public int ProfileId { get; set; }
    }
}
