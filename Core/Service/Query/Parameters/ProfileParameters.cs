using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Query.Parameters
{
    public class ProfileParameters : QueryStringParameters
    {
        public ProfileParameters()
        {
            OrderBy = "ProfileId";
        }
        /// <summary>
        /// Username of a profile to search for
        /// </summary>
        public string Username { get; set; }
    }
}
