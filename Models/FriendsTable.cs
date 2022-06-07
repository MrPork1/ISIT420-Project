using System;
using System.Collections.Generic;

namespace ISIT420_Project.Models
{
    public partial class FriendsTable
    {
        public int FriendsId { get; set; }
        public int? FrequencyId { get; set; }
        public int? AgeId { get; set; }
        public int? GenderId { get; set; }
        public string? Region { get; set; }
        public double? Percentage { get; set; }

        public virtual AgeTable? Age { get; set; }
        public virtual FrequencyTable? Frequency { get; set; }
        public virtual GenderTable? Gender { get; set; }
    }
}
