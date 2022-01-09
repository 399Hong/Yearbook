using yearbook.Models;
using yearbook.Data;

using HotChocolate.Types;

using Microsoft.EntityFrameworkCore;

namespace yearbook.GraphQL.Students;


    public class StudentResolvers: ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {

            descriptor
                .Field(s => s.Projects)
                .ResolveWith<Resolvers>(r => r.GetProjects(default!, default!, default))
                .UseDbContext<appDbContext>();
                //.Type<NonNullType<ListType<NonNullType<ProjectType>>>>();

            descriptor
                .Field(s => s.Comments)
                .ResolveWith<Resolvers>(r => r.GetComments(default!, default!, default))
                .UseDbContext<appDbContext>();
                //.Type<NonNullType<ListType<NonNullType<CommentType>>>>();
        }

        private class Resolvers
        {
            // stablish DB relationship
            public async Task<IEnumerable<Project>> GetProjects([Parent] Student student, [ScopedService] appDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Projects.Where(c => c.StudentId == student.id).ToArrayAsync(cancellationToken);
            }

            public async Task<IEnumerable<Comment>> GetComments(Student student, [ScopedService] appDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Comments.Where(c => c.StudentId == student.id).ToArrayAsync(cancellationToken);
            }
        }
    }
