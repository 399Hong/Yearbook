using yearbook.Data;
using yearbook.Models;

using Microsoft.EntityFrameworkCore;

namespace yearbook.GraphQL.Comments;

[ExtendObjectType(name :"Query")]
public class CommentQueries
{   
    [UseDbContext(typeof(appDbContext))]
    //[UsePaging]// paging requires IEnumerable or Iqueryable;
    public IQueryable<Comment> GetComments([ScopedService] appDbContext context)
    {
        return context.Comments.OrderBy(c => c.Created);
    }

   [UseDbContext(typeof(appDbContext))]
    public Comment GetComment(int id, [ScopedService] appDbContext context)
    {
        return context.Comments.Find(id);
    }
}
