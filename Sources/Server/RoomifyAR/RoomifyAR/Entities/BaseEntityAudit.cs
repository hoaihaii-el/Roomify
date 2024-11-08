using System.ComponentModel.DataAnnotations;

namespace RoomifyAR.Entities
{
    public class BaseEntityAudit
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
