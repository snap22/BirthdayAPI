using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
