using Devalaya.Explorer.API.Middleware;
using Devalaya.Explorer.DataAccess;
using Devalaya.Explorer.DataAccess.Repositories;
using Devalaya.Explorer.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<ITemplesRepository, TemplesRepository>();

var app = builder.Build();


app.UseMiddleware<ExceptionHandlingMiddleware>();



app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
