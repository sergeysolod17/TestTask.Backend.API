using System.ComponentModel.DataAnnotations;

namespace Backend.API.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        public string Name { get; set; }        
        
        [Required]
        public string Email { get; set; }

        [MaxLength(13)]
        public string Phone{ get; set; }
    }
}
