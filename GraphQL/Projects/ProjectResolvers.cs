using yearbook.Data;
using yearbook.Models;

using Microsoft.EntityFrameworkCore;

namespace yearbook.GraphQL.Projects;



        public class ProjectResolvers : ObjectType<Project>
        {
                protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
                {


                        descriptor
                                .Field(p => p.Student)
                                .ResolveWith<Resolvers>(r => r.GetStudent(default!, default!, default))
                                .UseDbContext<appDbContext>();
                        //.Type<NonNullType<StudentType>>();

                        descriptor
                                .Field(p => p.Comments)
                                .ResolveWith<Resolvers>(r => r.GetComments(default!, default!, default))
                                .UseDbContext<appDbContext>();
                        //.Type<NonNullType<ListType<NonNullType<CommentType>>>>();


                }

                private class Resolvers
                {
                        public async Task<Student> GetStudent([Parent] Project project, [ScopedService] appDbContext context,
                        CancellationToken cancellationToken)
                        {
                        return await context.Students.FindAsync(new object[]{ project.StudentId }, cancellationToken);
                        }

                        public async Task<IEnumerable<Comment>> GetComments( [Parent] Project project, [ScopedService] appDbContext context,
                        CancellationToken cancellationToken)
                        {
                        return await context.Comments.Where(c => c.ProjectId == project.Id).ToArrayAsync(cancellationToken);
                        }
                }
        }
