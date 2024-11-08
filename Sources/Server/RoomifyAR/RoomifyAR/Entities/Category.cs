using System.ComponentModel.DataAnnotations;

namespace RoomifyAR.Entities
{
    public class Category : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
