## dotnet ef command
**mac**

```shell
// add migration
dotnet ef migrations add {name}
// update database according to the migrations
dotnet ef database update

```
# GraphQl with HotChocolate
## mutation.

need to return the original object, and other relevant info is added by the database.
```csharp
    [UseDbContext(typeof(appDbContext))]
    public async Task<Student> AddStudent(AddStudentInput input, [ScopedService] appDbContext context, CancellationToken ct){
       

       // new student object
        var student = new Student
        {
            name = input.name,
            Github= input.github,
            imageURI = input.imageUrl,
        };
       context.Add(student);
       
       await context.SaveChangesAsync(ct);
        // **id** automatically retrieve once its inserted into the database
       return student;
```
# authentication
https://www.learmoreseekmore.com/2021/03/part1-hotchocolate-graphql-custom-authentication-series-using-pure-code-first-technique-user-registration.html
# jwt authentication
## audiance
Audience represents the **intended recipient** of the **incoming token** or the **resource that the token grants access to**. If the value specified in this parameter doesn’t match the aud parameter in the token, the token will be rejected because it was meant to be used for accessing a different resource. Note that different security token providers have different behaviors regarding what is used as the ‘aud’ claim (some use the URI of a resource a user wants to access, others use scope names). Be sure to use an audience that makes sense given the tokens you plan to accept.
## ValidIssuer, ValidateIssuerSigningKey use tgt (authority)
1. validIssuer properties indicate that the token’s signature should be validated
2. the key’s property indicating it’s issuer must match an expected value.

This is an alternate way to make sure the issuer is validated without using authority. instead of authorty, the JWT’s issuer is matched against custom values that are provided by the **ValidIssuer or ValidIssuers** properties of the TokenValidationParameters object.

## JwtSecurityToken
it should be at least 128bit.
otherwise
> Error: IDX10653: The encryption algorithm 'System.String' requires a key size of at least 'System.Int32' bits. Key 'Microsoft.IdentityModel.Tokens.SymmetricSecurityKey', is of size: 'System.Int32'. (Parameter 'key')



# octokit
https://docs.github.com/en/rest/guides/getting-started-with-the-rest-api
https://github.com/octokit/octokit.net/blob/main/docs/getting-started.md

### valueTask

A Task represents the state of some operation, i.e., whether the operation is completed, cancelled, and so on. An asynchronous method can return either a Task or a ValueTask.

Now, since Task is a reference type, returning a Task object from an asynchronous method implies allocating the object on the managed heap each time the method is called. Thus, one caveat in using Task is that you need to allocate memory in the managed heap every time you return a Task object from your method. If the result of the operation being performed by your method is available immediately or completes synchronously, this allocation is not needed and therefore becomes costly.

Here is exactly where ValueTask comes to the rescue. ValueTask<T> provides two major benefits. First, ValueTask<T> improves performance because it doesn’t need heap allocation, and second, it is both easy and flexible to implement. By returning ValueTask<T> instead of Task<T> from an asynchronous method when the result is immediately available, you can avoid the unnecessary overhead of allocation since “T” here represents a structure and a struct in C# is a value type (in contrast to the “T” in Task<T>, which represents a class).

Task and ValueTask represent two primary “awaitable” types in C#. Note that you cannot block on a ValueTask. If you need to block you should convert the ValueTask to a Task using the AsTask method and then block on that reference Task object.

Also note that each ValueTask can be consumed only once. Here the word “consume” implies that a ValueTask can asynchronously wait for (await) the operation to complete or take advantage of AsTask to convert a ValueTask to a Task. However, a ValueTask should be consumed only once, after which the ValueTask<T> should be ignored.
https://www.infoworld.com/article/3565433/how-to-use-valuetask-in-csharp.html
