using System.ComponentModel.DataAnnotations;

namespace RoomifyAR.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
