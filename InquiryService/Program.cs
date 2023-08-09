using InquiryService.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Inquiry Service",
        Description = "API InfinitIMO - Inquiry Service",
        Version = "v1"
    });

    var filename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filepath = Path.Combine(AppContext.BaseDirectory, filename);
    c.IncludeXmlComments(filepath);
});


// Configure DbContext for Property
builder.Services.AddDbContext<InquiryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddHttpClient();
builder.Services.AddScoped<InquiryService.Services.InquiryService>();


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
