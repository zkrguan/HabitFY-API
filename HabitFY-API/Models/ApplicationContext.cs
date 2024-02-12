using Microsoft.EntityFrameworkCore;

namespace HabitFY_API.Models
{
    // Simple DbContext initialization with 'new'
    // https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        
        
        }
        // ________________wire up the models into ef__________________
        public DbSet<Goal> Goals { get; set; }
        public DbSet<ProgressRecord>  ProgressRecords { get; set; }
        public DbSet<UserProfile> Userprofiles { get; set; }

    }

}
