using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testsystem.Models.Entities
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public Candidat Candidat { get; set; }
        public int CandidatId { get; set; }

        public Test Test { get; set; }
        public int TestId { get; set; }

        public List<Rating> Rating { get; set; } = new List<Rating>();

        public Guid Reference { get; set; }

        public string Content { get; set; }
    }
}
