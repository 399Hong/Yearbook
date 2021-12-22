using yearbook.Data;
using yearbook.Models;

namespace yearbook.GraphQL.Projects
{
 [ExtendObjectType("Mutation")]
    public class ProjectMutations
    {
        [UseDbContext(typeof(appDbContext))]
        public async Task<Project> AddProjectAsync(AddProjectInput input,
            [ScopedService] appDbContext context, CancellationToken ct)
        {
            var project = new Project
            {
                Name = input.Name,
                Description = input.Description,
                Link = input.Link,
                Year = (Year)Enum.Parse(typeof(Year), input.Year),
                StudentId = int.Parse(input.StudentId),
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };
            context.Projects.Add(project);

            await context.SaveChangesAsync(ct);

            return project;
        }

        [UseDbContext(typeof(appDbContext))]
        public async Task<Project> EditProjectAsync(EditProjectInput input,
            [ScopedService] appDbContext context, CancellationToken ct)
        {
            var project = await context.Projects.FindAsync(int.Parse(input.ProjectId));

            project.Name = input.Name ?? project.Name;
            project.Description = input.Description ?? project.Description;
            project.Link = input.Link ?? project.Link;
            project.Modified = DateTime.Now;

            await context.SaveChangesAsync(ct);

            return project;
        }
    }
}