using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Models.DTO
{
    public class GiftDto
    {
        public int GiftId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double EstimatedPrice { get; set; }
        public int ContactId { get; set; }
    }
}
