using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.DTOs
{
    public class ProfileDto
    {
        public int ProfileId { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public int AccountId { get; set; }
    }
}
