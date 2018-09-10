using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testsystem.models
{
    public class Viewer
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [Required]
        public long InvitationDate { get; set; }
      
    }
}
