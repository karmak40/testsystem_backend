using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testsystem.Models.Entities
{
    public class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public long Time { get; set; }

        public Position Position { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();

    }
}
