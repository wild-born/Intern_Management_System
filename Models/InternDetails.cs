using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intern_Management_System.Models
{
    public class InternDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int S_No { get; set; }
        public string InternId { get; set; }
        public string InternName { get; set; }
        public string PhoneNo { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public string Address1 { get; set; }
       
        

    }

}
