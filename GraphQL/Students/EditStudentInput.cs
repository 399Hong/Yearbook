namespace yearbook.GraphQL.Students;

public record EditStudentInput(
    string id, // id is required to edit student info, it cannot be null
    string? name,
    string? github,
    string? imageURI
);
