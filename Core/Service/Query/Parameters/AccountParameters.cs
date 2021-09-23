using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Query.Parameters
{

    public class AccountParameters : QueryStringParameters
    {
        public AccountParameters()
        {
            OrderBy = "AccountId";
        }
        /// <summary>
        /// Minimal year of account creation
        /// </summary>
        public uint MinYearOfCreation { get; set; }
        /// <summary>
        /// Maximal year of account creation
        /// </summary>
        public uint MaxYearOfCreation { get; set; } = (uint)DateTime.Now.Year;
        public bool IsValidYearRange() => MinYearOfCreation < MaxYearOfCreation;
        /// <summary>
        /// Email address to search for
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
