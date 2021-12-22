using yearbook.Data;
using yearbook.Models;



namespace yearbook.GraphQL.Students;

[ExtendObjectType ("Mutation")]
public class StudentMutations
{   
    [UseDbContext(typeof(appDbContext))]
    public async Task<Student> AddStudent(AddStudentInput input, [ScopedService] appDbContext context, CancellationToken ct){
       
        var student = new Student
        {
            name = input.name,
            Github= input.github,
            imageURI = input.imageUrl,
        };
       context.Add(student);
       
       await context.SaveChangesAsync(ct);

       return student;
       // return student to indicate the type of payload.
       // hc handles the retrieval.
       //i think the await context.SaveChangesAsync(ct);
       // retrieve the id and store it back into student

       //the following sql used for mutation
        //   Executed DbCommand (36ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000), @p2='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
        //   SET NOCOUNT ON;
        //   INSERT INTO [Students] ([Github], [imageURI], [name])
        //   VALUES (@p0, @p1, @p2);
        //   SELECT [id]
        //   FROM [Students]
        //   WHERE @@ROWCOUNT = 1 AND [id] = scope_identity();
        
       
    }
    [UseDbContext(typeof(appDbContext))]
     public async Task<Student> EditStudentAsync(EditStudentInput input,
                [ScopedService] appDbContext context, CancellationToken ct)
        {
            var student = await context.Students.FindAsync(int.Parse(input.id));

            student.name = input.name ?? student.name;
            student.Github = input.github ?? student.Github;
            student.imageURI = input.imageURI?? student.imageURI;

            await context.SaveChangesAsync(ct);

            return student;
        }
}
