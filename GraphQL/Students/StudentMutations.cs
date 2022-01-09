using yearbook.Data;
using yearbook.Models;
using Octokit;

using static System.Console;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

using HotChocolate.AspNetCore;

using System.Security.Claims;





namespace yearbook.GraphQL.Students;


[ExtendObjectType ("Mutation")]
public class StudentMutations
{   
    private readonly IConfiguration Configuration;

    public StudentMutations(IConfiguration configuration)
    {
        Configuration = configuration;
        // DI
    }


    [UseDbContext(typeof(appDbContext))]
    public async Task<Student> AddStudent(AddStudentInput input, 
    [ScopedService] appDbContext context, CancellationToken ct){
       
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
    //[Authorize]
     public async Task<Student> EditStudentAsync(EditStudentInput input, ClaimsPrincipal claimsUser,
                [ScopedService] appDbContext context, CancellationToken ct)
    {
            var userId = claimsUser.FindFirstValue("id");
            var student = await context.Students.FindAsync(int.Parse(userId),ct);

            student.name = input.name ?? student.name;
            student.Github = input.github ?? student.Github;
            student.imageURI = input.imageURI?? student.imageURI;

            await context.SaveChangesAsync(ct);
            

            return student;
    }


    [UseDbContext(typeof(appDbContext))]
    public async Task<LoginPayload> LoginAsync(LoginInput input, [ScopedService] appDbContext context, CancellationToken ct)
    {
        var client = new GitHubClient(new ProductHeaderValue("yearbook"));
        //name used should represent the product, the GitHub Organization, or the GitHub username that's using Octokit.net (in that order of preference).
        //see notes for more info
        WriteLine("here");
        var request = new OauthTokenRequest(Configuration["Github:ClientID"], Configuration["Github:ClientSecret"], input.Code);
        // authenticated request
        var tokenInfo = await client.Oauth.CreateAccessToken(request);
      
        if (tokenInfo.AccessToken == null)
        {
            throw new GraphQLRequestException(ErrorBuilder.New()
                .SetMessage("Bad code")
                .SetCode("AUTH_NOT_AUTHENTICATED")
                .Build());
        }
        // use access token to get user
        client.Credentials = new Credentials(tokenInfo.AccessToken);

        var user = await client.User.Current();
        // check for exsistence of user
        var student = await context.Students.FirstOrDefaultAsync(s => s.Github == user.Login, ct);

            if (student == null)
            { // create a student if not found

                student = new Student
                {
                    name = user.Name ?? user.Login,
                    Github = user.Login,
                    imageURI= user.AvatarUrl,
                };

                context.Students.Add(student);
                await context.SaveChangesAsync(ct);
            }
            WriteLine("succesful get stu");
            // authentication successful so generate jwt token
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>{
                new Claim("id",student.id.ToString()),
                //A claim is a name value pair that represents what the subject is,
                // not what the subject can do.
            };

            var jwtToken = new JwtSecurityToken(
                "issuer",
                "aud",
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: credentials );

       
            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            //IDX10653: The encryption algorithm 'System.String' requires a key size of at least 'System.Int32' bits. Key 'Microsoft.IdentityModel.Tokens.SymmetricSecurityKey', is of size: 'System.Int32'. (Parameter 'key')
            // key size should longer than 'System.Int32'
  
            return new LoginPayload(student, token);
    }
}