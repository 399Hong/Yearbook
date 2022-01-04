namespace yearbook.GraphQL.Students;

public record AddStudentInput
(
    string name,
    string github,
    string? imageUrl
);

