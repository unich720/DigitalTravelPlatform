using System.Collections.Generic;

#nullable disable

namespace DTP.Entity.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public short Id { get; set; }
        public string QuestionText { get; set; }
        public short PollId { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
