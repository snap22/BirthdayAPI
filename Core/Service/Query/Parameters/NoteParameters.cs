using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Query.Parameters
{
    public class NoteParameters : QueryStringParameters
    {
        public NoteParameters()
        {
            OrderBy = "NoteId";
        }

        public string Title { get; set; }
    }
}
