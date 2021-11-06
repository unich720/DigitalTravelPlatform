using System.Collections.Generic;

#nullable disable

namespace DTP.Entity.Models
{
    public partial class Poll
    {
        public Poll()
        {
            Questions = new HashSet<Question>();
        }

        public short Id { get; set; }
        public string PollName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
