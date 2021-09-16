﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.DTOs
{
    public class NoteDto
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProfileId { get; set; }
    }
}
