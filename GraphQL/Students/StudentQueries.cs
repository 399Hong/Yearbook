
using yearbook.Data;
using yearbook.Models;

using System.Security.Claims;
using HotChocolate.AspNetCore.Authorization;


namespace yearbook.GraphQL.Students;



[ExtendObjectType(name :"Query")]// enable HC to identify this class as a query class, 
//so that we can have mutiple queries 

public class StudentQueries{

    [UseDbContext(typeof(appDbContext))]
    public IQueryable<Student> GetStudents([ScopedService] appDbContext context){
        return context.Students;
    }

    [UseDbContext(typeof(appDbContext))]
    public Student GetStudent([GraphQLType(typeof(NonNullType<IdType>))] string id, [ScopedService] appDbContext context)
    {
        return context.Students.Find(int.Parse(id));
    }
    // [UseDbContext(typeof(appDbContext))]
    // [Authorize]
    // public Student GetSelf(ClaimsPrincipal claimsPrincipal, [ScopedService] appDbContext context)
    // {
    //     var studentIdStr = claimsPrincipal.FindFirstValue("id");

    //     return context.Students.Find(int.Parse(studentIdStr));
    // }

}
