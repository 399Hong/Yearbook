
using yearbook.Models;
using yearbook.Data;
namespace yearbook.GraphQL.Comments;

public class CommentResolvers : ObjectType<Comment>
{


    protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
    {
        descriptor
            .Field(s => s.Project)
            .ResolveWith<Resolvers>(r => r.GetProject(default!, default!, default))
            .UseDbContext<appDbContext>();
                //.Type<NonNullType<ProjectType>>();

            descriptor
                .Field(s => s.Student)
                .ResolveWith<Resolvers>(r => r.GetStudent(default!, default!, default))
                .UseDbContext<appDbContext>();
        //.Type<NonNullType<StudentType>>();

    }

    private class Resolvers
    {
        public async Task<Project> GetProject([Parent]Comment comment, [ScopedService] appDbContext context,
            CancellationToken cancellationToken)
        {
            return await context.Projects.FindAsync(new object[] { comment.ProjectId }, cancellationToken);
        }

        public async Task<Student> GetStudent([Parent]Comment comment, [ScopedService] appDbContext context,
            CancellationToken cancellationToken)
        {
            return await context.Students.FindAsync(new object[] { comment.StudentId }, cancellationToken);
        }
    }


}
