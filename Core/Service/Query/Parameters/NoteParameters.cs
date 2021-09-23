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

        /// <summary>
        /// Title of a note to search for
        /// </summary>
        public string Title { get; set; }
    }
}
