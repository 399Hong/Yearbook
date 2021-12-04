using HotChocolate.Types;
using yearbook.Data;
using yearbook.Models;

namespace yearbook.GraphQL.Students;



[ExtendObjectType(name :"Query")]// enable HC to identify this class as a query class, 
//so that we can have mutiple queries 

public class StudentQueries{

    public IQueryable<Student> GetStudents([ScopedService] appDbContext context){
        return context.Students;
    }

}
