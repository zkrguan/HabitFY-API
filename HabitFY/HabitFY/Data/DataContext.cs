using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HabitFY.Data
{
    public class DataContext:DbContext
    {
        //1. RG's notes: This is where the DBContext is initialized. "base(options)" C style expression to pass the options to the base constructor.
        // Just a sexier way to code something like Super() in nodejs
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
        
        }

        ////2. RG's note: Nothing fancy just the EF format to connect DB with the Model
        //public DbSet<ModelName> ModelNames { get; set; }


        // 3. RG's note: I see people use this way to set up the many to many (which is slightly different than MVC EF)
        // https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many

        // the idea is not new though if you ever tried nest.js. It is like using life cycle hooks. 
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //    modelBuilder.Entity<Post>()
        //        .HasMany(e => e.Tags)
        //        .WithMany(e => e.Posts);
        // }

        // Or you could have join table (DB ppl call bridging table)
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Post>()
        //        .HasMany(e => e.Tags)
        //        .WithMany(e => e.Posts)
        //        .UsingEntity("PostsToTagsJoinTable");
        //}

        // 4. Before you forget, you need to add the DBContext and the EF into the program.cs
    
        // 5. Run migration commands if you still remember because you added new contents. 
    }
}
