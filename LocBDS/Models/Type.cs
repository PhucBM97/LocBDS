using System;
using System.Collections.Generic;

namespace LocBDS.Models
{
    public partial class Type
    {
        public Type()
        {
            RealEstates = new HashSet<RealEstate>();
        }

        public int Id { get; set; }
        public string? TypeName { get; set; }

        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
