using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testsystem.Models.Entities
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        public int Grade { get; set; }

        public int AnswerId { get; set; }

        public int ViewerId { get; set; }

        public Viewer Viewer { get; set; }

        public Answer Answer { get; set; }

    }
}
