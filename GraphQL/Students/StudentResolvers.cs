using yearbook.Models;
using yearbook.Data;

using Microsoft.EntityFrameworkCore;
namespace yearbook.GraphQL.Students;


[ExtendObjectType(name :"Query")]
public class StudentResolvers{

        public async Task<IEnumerable<Project>> GetProjects(Student student, [ScopedService] appDbContext context,
            CancellationToken cancellationToken)
        {
            return await context.Projects.Where(c => c.StudentId == student.id).ToArrayAsync(cancellationToken);
            // inconsistent name, need to be updated
        }

        public async Task<IEnumerable<Comment>> GetComments(Student student, [ScopedService] appDbContext context,
            CancellationToken cancellationToken)
        {
            return await context.Comments.Where(c => c.StudentId == student.id).ToArrayAsync(cancellationToken);
        }


}
