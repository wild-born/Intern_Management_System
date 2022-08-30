using Intern_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern_Management_System.CRUDContext
{
    public class CRUD : DbContext
    {
        public CRUD(DbContextOptions<CRUD> options) : base(options)
        {

        }
        public DbSet<designationDetails> DesignationDetail { get; set; }
        public DbSet<InternDetails> InternDetails{ get; set; }
        public DbSet<RequestLeave> RequestLeaves { get; set; }
    }
}
