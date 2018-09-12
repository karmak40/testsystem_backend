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

        public string Number { get; set; }

        public string Name { get; set; }

        public long Time { get; set; }
   
        public string Answer { get; set; }

        public Position Position { get; set; }

        public List<Rating> Rating { get; set; } = new List<Rating>();

    }
}
