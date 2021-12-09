using yearbook.Models;
using yearbook.Data;
namespace yearbook.GraphQL.Projects;

[ExtendObjectType(name: "Query")]
public class ProjectQueries
{
    
    [UseDbContext(typeof(appDbContext))]
    //[UsePaging]// paging requires IEnumerable or Iqueryable;
    public IQueryable<Project> GetProjects([ScopedService] appDbContext context)
    {
        return context.Projects.OrderBy(c => c.Created);
    }

   [UseDbContext(typeof(appDbContext))]
    public Project GetProject(int id, [ScopedService] appDbContext context)
    {
        return context.Projects.Find(id);
    }
}
