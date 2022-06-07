using System;
using System.Collections.Generic;

namespace ISIT420_Project.Models
{
    public partial class FrequencyTable
    {
        public FrequencyTable()
        {
            FriendsTables = new HashSet<FriendsTable>();
            ParticipationTables = new HashSet<ParticipationTable>();
        }

        public int FrequencyId { get; set; }
        public string? Frequency { get; set; }

        public virtual ICollection<FriendsTable> FriendsTables { get; set; }
        public virtual ICollection<ParticipationTable> ParticipationTables { get; set; }
    }
}
