using Microsoft.EntityFrameworkCore;
using N_TierArchitectureToDoApp.DataDomain.Entities;

namespace N_TierArchitectureToDoApp.DataDomain.DbContexts
{
    public partial class ToDoAppDbContext : DbContext
    {
        public ToDoAppDbContext()
        {
        }

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Work> Works { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
