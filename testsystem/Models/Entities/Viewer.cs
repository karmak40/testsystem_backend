using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testsystem.Models.Entities
{
    public class Viewer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [Required]
        public long InvitationDate { get; set; }

        public Position Position { get; set; }

        public string Number { get; set; }

        public List<Rating> Tests { get; set; } = new List<Rating>();

    }
}
