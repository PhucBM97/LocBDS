using System;
using System.Collections.Generic;

namespace LocBDS.Models
{
    public partial class RealEstate
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Area { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }

        public virtual Type? Type { get; set; }
    }
}
