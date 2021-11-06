#nullable disable

namespace DTP.Entity.Models
{
    public partial class Answer
    {
        public short Id { get; set; }
        public string AnswerText { get; set; }
        public short QuestionId { get; set; }
        public short Count { get; set; }

        public virtual Question Question { get; set; }
    }
}
