using System;
using System.Collections.Generic;

namespace LocBDS.Models
{
    public partial class RealEstate
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? Price { get; set; }
        public string? Area { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public string? Photo { get; set; }

        public virtual Category? Category { get; set; }
    }
}
