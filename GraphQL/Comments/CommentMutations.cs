using yearbook.Models;
using yearbook.Data;

using System.Security.Claims;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Authorization;

namespace yearbook.GraphQL.Comments
{
[ExtendObjectType("Mutation")]
    public class CommentMutations
    {
        [UseDbContext(typeof(appDbContext))]
        [Authorize]
        public async Task<Comment> AddCommentAsync(AddCommentInput input, ClaimsPrincipal claimsUser,
        [ScopedService] appDbContext context, CancellationToken ct)
        {   
            var userId = claimsUser.FindFirstValue("id");
            var comment = new Comment
            {
                Content = input.Content,
                ProjectId = int.Parse(input.ProjectId),
                StudentId = int.Parse(userId),
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };
            context.Comments.Add(comment);

            await context.SaveChangesAsync(ct);

            return comment;
        }

        [UseDbContext(typeof(appDbContext))]
        [Authorize]
        public async Task<Comment> EditCommentAsync(EditCommentInput input, ClaimsPrincipal claimsUser,
                [ScopedService] appDbContext context, CancellationToken ct)
        {
            var userId = claimsUser.FindFirstValue("id");
            var comment = await context.Comments.FindAsync(int.Parse(input.CommentId));

            if (comment.StudentId != int.Parse(userId))
            {
                throw new GraphQLRequestException(ErrorBuilder.New()
                    .SetMessage("Not owned by student")
                    .SetCode("AUTH_NOT_AUTHORIZED")
                    .Build());
            }
            
            comment.Content = input.Content ?? comment.Content;

            await context.SaveChangesAsync(ct);

            return comment;
        }
    }

}