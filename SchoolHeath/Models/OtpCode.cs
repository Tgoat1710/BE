using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolHealth.Models
{
    public class OtpCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = null!;

        [Required]
        public DateTime Expiration { get; set; }
    }
}
