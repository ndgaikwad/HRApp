using Microsoft.EntityFrameworkCore;

namespace OpenShiftHRapp.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> opt) : base(opt)
        {

        }

        public DbSet<Emp> Emps { get; set; }
    }
}
