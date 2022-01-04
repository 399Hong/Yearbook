using yearbook.Data;
using yearbook.GraphQL.Students;
using yearbook.GraphQL.Comments;
using yearbook.GraphQL.Projects;
using Microsoft.EntityFrameworkCore;

// authentication
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


//5Kst8KDc5Ef4?x#$j_
var builder = WebApplication.CreateBuilder(args);
//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPooledDbContextFactory<appDbContext>
// allow reuse instance
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddGraphQLServer()
                .AddMutationConventions(applyToAllMutations: true)
                // trying to add input payload convension to reduce the amount of boilerplate code
                // but can find it lol.
                // it requirs the latest version of hc
                // it is diffcuilt to customize input and payload.
                .AddQueryType()// add all query under the extention query
                    .AddTypeExtension<StudentQueries>()// adding queries for every object
                    .AddTypeExtension<CommentQueries>()
                    .AddTypeExtension<ProjectQueries>()
                .AddType<StudentResolvers>() // adding resolvers for nested query
                .AddType<ProjectResolvers>()// naming should be changed... but im too lazy.
                .AddType<CommentResolvers>()
                .AddMutationType()
                    .AddTypeExtension<StudentMutations>()
                    .AddTypeExtension<ProjectMutations>()
                    .AddTypeExtension<CommentMutations>();

var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidIssuer = "issuer",
                ValidAudience = "aud",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey
            };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    // force communication over https
    // prevent user from using untursted orinvalid certificates.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseEndpoints(Endpoints => {
    Endpoints.MapGraphQL();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
