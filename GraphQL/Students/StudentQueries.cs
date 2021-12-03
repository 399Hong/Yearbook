using HotChocolate.Types;
using yearbook.Data;
using yearbook.Models;

namespace yearbook.GraphQL.Students;



[ExtendObjectType(name :"Query")]// tells this class is for queries
public class StudentQueries{

    public IQueryable<Student> GetStudents([ScopedService] appDbContext context){
        return context.Students;
    }

}
