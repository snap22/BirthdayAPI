using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.QueryParameters
{

    public class AccountParameters : QueryStringParameters
    {
        public uint MinYearOfCreation { get; set; }
        public uint MaxYearOfCreation { get; set; } = (uint)DateTime.Now.Year;
        public bool IsValidYearRange() => MinYearOfCreation < MaxYearOfCreation;
        public string EmailAddress { get; set; }
    }
}
