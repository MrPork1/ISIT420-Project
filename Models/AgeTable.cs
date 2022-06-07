using System;
using System.Collections.Generic;

namespace ISIT420_Project.Models
{
    public partial class AgeTable
    {
        public AgeTable()
        {
            FriendsTables = new HashSet<FriendsTable>();
            ParticipationTables = new HashSet<ParticipationTable>();
        }

        public int AgeId { get; set; }
        public string? AgeRange { get; set; }

        public virtual ICollection<FriendsTable> FriendsTables { get; set; }
        public virtual ICollection<ParticipationTable> ParticipationTables { get; set; }
    }
}
