namespace yearbook.GraphQL.Students;

public record AddStudentInput
(
    string name,
    string github,
    string? imageUrl
    //mmutable request bindings are an ideal user case for a record
);

