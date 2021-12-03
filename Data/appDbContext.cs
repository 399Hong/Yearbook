using Microsoft.EntityFrameworkCore;
using yearbook.Models;
namespace yearbook.Data;

public class appDbContext: DbContext {
    
    public appDbContext(DbContextOptions options) : base (options){}
    //The DbContextOptions instance carries configuration information
    //such as the connection string, database provider to use etc.
    // non-genetic due to single dbcontext
    
    public DbSet<Student> Students {get;set;}


}