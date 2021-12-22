namespace yearbook.GraphQL.Comments
{
public record EditCommentInput(
        string CommentId,
        string? Content);
}