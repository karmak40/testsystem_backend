using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testsystem.Models.Entities
{
    public class Candidat
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

        public string Number { get; set; }

        public long InvitationDate { get; set; }

        public long ExpiredDate { get; set; }

        public string Phone { get; set; }

        public Position Position { get; set; }
    }
}
