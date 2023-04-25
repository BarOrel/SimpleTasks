using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleTasks.Data;
using SimpleTasks.Data.Models;
using SimpleTasks.Data.Repository;
using SimpleTasks.Services.UserService;
using System.Text;
using ToDoListPractice.Data.Services.JWT;
using ToDoListPractice.Data.Services;
using SimpleTasks.Services.TaskService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<SimpleTask_DbContext>(options =>
    options.UseSqlServer("Data Source=Desktop-MGPQKAT;Initial Catalog=SimpleTasks;Integrated Security=True;Pooling=False;trustServerCertificate=true"));

builder.Services.AddAuthentication(cnf =>
{
    cnf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cnf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = false,
    };
});

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<SimpleTask_DbContext>();


builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IJWTTokenService, JWTTokenService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => options.AddPolicy(name: "clientsOrigins",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    }));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("clientsOrigins");
app.MapControllers();

app.Run();


//Data Source=DESKTOP-MGPQKAT;Initial Catalog=SimpleTask_DB;Integrated Security=True;Pooling=False