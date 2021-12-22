using yearbook.Models;
using yearbook.Data;

namespace yearbook.GraphQL.Comments
{
[ExtendObjectType("Mutation")]
    public class CommentMutations
    {
        [UseDbContext(typeof(appDbContext))]
        public async Task<Comment> AddCommentAsync(AddCommentInput input,
        [ScopedService] appDbContext context, CancellationToken ct)
        {
            var comment = new Comment
            {
                Content = input.Content,
                ProjectId = int.Parse(input.ProjectId),
                StudentId = int.Parse(input.StudentId),
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };
            context.Comments.Add(comment);

            await context.SaveChangesAsync(ct);

            return comment;
        }

         [UseDbContext(typeof(appDbContext))]
        public async Task<Comment> EditCommentAsync(EditCommentInput input,
                [ScopedService] appDbContext context, CancellationToken ct)
        {
            var comment = await context.Comments.FindAsync(int.Parse(input.CommentId));
            
            comment.Content = input.Content ?? comment.Content;

            await context.SaveChangesAsync(ct);

            return comment;
        }
    }

}