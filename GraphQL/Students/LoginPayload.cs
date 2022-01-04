using yearbook.Models;
namespace yearbook.GraphQL.Students
{
    public record LoginPayload(
        Student student,
        string jwt);
}