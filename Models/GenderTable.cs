using System;
using System.Collections.Generic;

namespace ISIT420_Project.Models
{
    public partial class GenderTable
    {
        public GenderTable()
        {
            FriendsTables = new HashSet<FriendsTable>();
            ParticipationTables = new HashSet<ParticipationTable>();
        }

        public int GenderId { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<FriendsTable> FriendsTables { get; set; }
        public virtual ICollection<ParticipationTable> ParticipationTables { get; set; }
    }
}
