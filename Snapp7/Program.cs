using Microsoft.EntityFrameworkCore;
using Snapp.Core.Interfaces;
using Snapp.Core.Senders;
using Snapp.Core.Services;
using Snapp.DataAccessLayer.Context;


var builder = WebApplication.CreateBuilder(args);

#region DatabaseContext
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion

#region InterfaceServices
builder.Services.AddScoped<IAccount, AccountService>();
builder.Services.AddScoped<IAdmin, AdminService>();

#endregion

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);


var app = builder.Build();



app.UseMvcWithDefaultRoute();
app.UseRouting();
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();
