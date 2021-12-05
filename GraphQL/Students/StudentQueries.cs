using HotChocolate.Types;
using yearbook.Data;
using yearbook.Models;

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

}
