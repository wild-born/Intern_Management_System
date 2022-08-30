using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intern_Management_System.Models
{
    public class RequestLeave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string InternId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string When { get; set; }
        public string Reason { get; set; }
    }
}

