using Microsoft.EntityFrameworkCore;
using Tasks.Data.Entities;

namespace Tasks.Data.Base
{
    public class TasksContext : DbContext
    {

        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("Task");

            base.OnModelCreating(modelBuilder);
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=tcp:ckoplin.database.windows.net,1433;Initial Catalog=ckoplindatabase;Persist Security Info=False;User ID=ckoplin;Password=H4ckdb123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("Tasks.Data"));

        }*/




        /*public class TaskContextFactory : IDesignTimeDbContextFactory<TasksContext>
        {
            public TasksContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<TasksContext>();
                var connection = @"Server=tcp:ckoplin.database.windows.net,1433;Initial Catalog=ckoplindatabase;Persist Security Info=False;User ID=ckoplin;Password=H4ckdb123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connection);

                return new TasksContext(optionsBuilder.Options);
            }
        }*/


    }
}
