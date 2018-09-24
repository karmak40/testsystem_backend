using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testsystem.Models.Entities
{
    public class Position
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public long OpenDate { get; set; }

        public long CloseDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        public string About { get; set; }

        public string CompanyInfo { get; set; }

        public string Instruction { get; set; }

        public long AvailableTime { get; set; }

        public List<Candidat> Candidats { get; set; } = new List<Candidat>();
        public List<Viewer> Viewers { get; set; } = new List<Viewer>();
        public List<Test> Tests { get; set; } = new List<Test>();
    }
}
