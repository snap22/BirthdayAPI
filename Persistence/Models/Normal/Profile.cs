﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Models.Normal
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
    }
}
