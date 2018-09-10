using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testsystem.models
{
    public class Candidat
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        public int Number { get; set; }
        public long InvitationDate { get; set; }
        public long ExpiredDate { get; set; }
        public string Phone { get; set; }
    }
}
