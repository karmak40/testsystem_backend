using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using testsystem.models;

namespace testsystem.Models
{
    public class Position
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        public long OpenDate { get; set; }

        public long CloseDate { get; set; }

        public string Status { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        public int Number { get; set; }

        public List<Candidat> Candidats { get; set; } = new List<Candidat>();
        public List<Viewer> Viewers { get; set; } = new List<Viewer>();
    }
}
