using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApiEntityFramework.Data;
using WebApiEntityFramework.Events.ChangeTracker;
using WebApiEntityFramework.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options=>options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["Default"], builder =>
    {
        builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
        builder.UseNetTopologySuite();
    });
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //options.UseModel(ApplicationDbContextModel.Instance);  optimize-dbcontext first
},ServiceLifetime.Scoped);
//builder.Services.AddDbContext<ApplicationDbContext>();
//builder.Services.AddDbContextPool<ApplicationDbContext>(...);
//builder.Services.AddDbContextFactory<ApplicationDbContext>(...);
//builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(...);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IChangeTrackerEvent, ChangeTrackerEventHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
}

app.Run();

