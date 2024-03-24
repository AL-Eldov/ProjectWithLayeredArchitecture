using mag2.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace mag2.DAL.EF;

public class TaskContext : DbContext
{
    public DbSet<Vector_f> Vector_f_Values { get; set; }
    public DbSet<Vector_c> Vector_c_Values { get; set; }
    public DbSet<Matrix_A> Marix_A_Values { get; set; }
    public DbSet<Vector_c_new> Vector_c_new_Values { get; set; }
    public DbSet<Vector_f_new> Vector_f_new_Values { get; set; }
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mag2DB;Username=testuser;Password=12345");
    }
    public void DeleteDB()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}
