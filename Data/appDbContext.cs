using Microsoft.EntityFrameworkCore;
using yearbook.Models;
namespace yearbook.Data;

public class appDbContext: DbContext {
    
    public appDbContext(DbContextOptions options) : base (options){}
    //The DbContextOptions instance carries configuration information
    //such as the connection string, database provider to use etc.
    // non-genetic due to single dbcontext
    
    public DbSet<Student> Students {get;set;}
    public DbSet<Comment> Comments {get;set;}
    public DbSet<Project> Projects {get;set;} 
    protected override void OnModelCreating( ModelBuilder mb){

        mb.Entity<Project>()
                            .HasOne( p => p.Student)
                            .WithMany( s => s.Projects)
                            .HasForeignKey(p => p.StudentId);
                           // it can be deleted
        mb.Entity<Comment>()
                            .HasOne(c => c.Student)
                            .WithMany(s => s.Comments)
                            .HasForeignKey( c => c.StudentId)
                            .OnDelete(DeleteBehavior.NoAction);// no action to  when student is deleted
        mb.Entity<Comment>()
                            .HasOne( c => c.Project)
                            .WithMany( p => p.Comments)
                            .HasForeignKey( c => c.ProjectId);
                            // it can be deleted



    }



}