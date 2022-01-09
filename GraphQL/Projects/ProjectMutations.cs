using yearbook.Data;
using yearbook.Models;

using System.Security.Claims;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Authorization;




namespace yearbook.GraphQL.Projects
{
    [ExtendObjectType("Mutation")]
        public class ProjectMutations
    {
        [UseDbContext(typeof(appDbContext))]
        [Authorize]

        public async Task<Project> AddProjectAsync(AddProjectInput input, ClaimsPrincipal claimsUser,
            [ScopedService] appDbContext context, CancellationToken ct)
        {   
            var userId = claimsUser.FindFirstValue("id");

            var project = new Project

            {
                Name = input.Name,
                Description = input.Description,
                Link = input.Link,
                Year = (Year)Enum.Parse(typeof(Year), input.Year),
                StudentId = int.Parse(userId),
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };
            context.Projects.Add(project);

            await context.SaveChangesAsync(ct);

            return project;
        }

        [UseDbContext(typeof(appDbContext))]
        [Authorize]
        public async Task<Project> EditProjectAsync(EditProjectInput input, ClaimsPrincipal claimsUser,
            [ScopedService] appDbContext context, CancellationToken ct)
        {   
            var userId = claimsUser.FindFirstValue("id");
            var project = await context.Projects.FindAsync(int.Parse(input.ProjectId));
            if (project.StudentId != int.Parse(userId))
            {
                throw new GraphQLRequestException(ErrorBuilder.New()
                    .SetMessage("Not owned by logged-in student")
                    .SetCode("AUTH_NOT_AUTHORIZED")
                    .Build());
            }


            project.Name = input.Name ?? project.Name;
            project.Description = input.Description ?? project.Description;
            project.Link = input.Link ?? project.Link;
            project.Modified = DateTime.Now;

            await context.SaveChangesAsync(ct);

            return project;
        }
    }
}