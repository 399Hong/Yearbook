using yearbook.Data;
using yearbook.GraphQL.Students;

using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static System.Console;

//5Kst8KDc5Ef4?x#$j_
var builder = WebApplication.CreateBuilder(args);
//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPooledDbContextFactory<appDbContext>
// allow reuse instance
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddGraphQLServer()
                .AddQueryType( d => d.Name("Query"))// add all query under the extention query
                .AddTypeExtension<StudentQueries>();


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
app.UseEndpoints(Endpoints => {
    Endpoints.MapGraphQL();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
