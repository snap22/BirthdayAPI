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
        public string Username { get; set; }
    }
}
