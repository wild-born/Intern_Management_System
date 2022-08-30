using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intern_Management_System.Models
{
    public class designationDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
       
        public string DepartmentName { get; set; }
        public string CompanyMonthlyHour { get; set; }
        public string InternMonthlyHour { get; set; }
        public string Status { get; set; }
        
    }
}
