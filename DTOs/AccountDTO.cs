using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LittleRepro.DTOs
{
    public class AccountDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? LastChangedAt { get; set; }

        public AccountDTO(
            int id,
            string name,
            string country,
            string email,
            DateTime createdAt,
            DateTime? lastChangedAt)
        {
            Id = id;
            Name = name;
            Country = country;
            Email = email;
            CreatedAt = createdAt;
            LastChangedAt = lastChangedAt;
        }
    }
}
