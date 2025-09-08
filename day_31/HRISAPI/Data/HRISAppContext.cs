using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace HRISAPI.Data
{
    public class HRISAppContext: DbContext
    {
        public HRISAppContext(DbContextOptions<HRISAppContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
