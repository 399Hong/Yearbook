namespace yearbook.GraphQL.Students;

public record EditStudentInput(
     // id is required to edit student info, it cannot be null
    string? name,
    string? github,
    string? imageURI
);
