#nullable disable

namespace DTP.Entity.Models
{
    public partial class MovementHistory
    {
        public short UserId { get; set; }
        public short PlaceId { get; set; }

        public virtual Place Place { get; set; }
        public virtual User User { get; set; }
    }
}
