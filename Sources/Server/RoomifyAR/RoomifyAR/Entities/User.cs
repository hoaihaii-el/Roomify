using System.ComponentModel.DataAnnotations;

namespace RoomifyAR.Entities
{
    public class User : BaseEntityAudit
    {
        [MaxLength(50)]
        public string Username { get; set; } = "";
        [MaxLength(50)]
        public string Email { get; set; } = "";
        [MaxLength(50)]
        public string Role { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }
}
