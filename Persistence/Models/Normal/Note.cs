using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Models.Normal
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public int Description { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
