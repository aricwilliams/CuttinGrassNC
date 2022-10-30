using CuttinGrassNCAPI.ApiMapper;
using CuttinGrassNCAPI.Data;
using CuttinGrassNCAPI.Model.DBCustomers;
using CuttinGrassNCAPI.Repository;
using CuttinGrassNCAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddAutoMapper(typeof(ApiMappings));
builder.Services.AddCors(aricsoptions =>
// use lamba experssion to all multiple lines of configerations 

{
    aricsoptions.AddPolicy("aricsCorsPolicy", builder =>
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}
app.UseCors("aricsCorsPolicy");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
