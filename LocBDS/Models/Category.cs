using System;
using System.Collections.Generic;

namespace LocBDS.Models
{
    public partial class Category
    {
        public Category()
        {
            RealEstates = new HashSet<RealEstate>();
        }

        public int Id { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
