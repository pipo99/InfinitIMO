using Microsoft.EntityFrameworkCore;
using PropertyService.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Property Service",
        Description = "API InfinitIMO - Property Service",
        Version = "v1"
    });

    var filename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filepath = Path.Combine(AppContext.BaseDirectory, filename);
    c.IncludeXmlComments(filepath);
});



builder.Services.AddSwaggerGen();

// Configure DbContext for Property
builder.Services.AddDbContext<PropertyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));



// Add your service configuration
builder.Services.AddScoped<PropertyService.Services.PropertyService>();


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

app.Run();
