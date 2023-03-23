using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using RewardsService.Auth;
using RewardsService.DataBase;
using RewardsService.Filters;
using RewardsService.Services;
using RewardsService.Services.Abstractions;
using System.Reflection;
using System.Text.Json.Serialization;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;
using Unchase.Swashbuckle.AspNetCore.Extensions.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddEnumsWithValuesFixFilters(o =>
    {
        // add schema filter to fix enums (add 'x-enumNames' for NSwag or its alias from XEnumNamesAlias) in schema
        o.ApplySchemaFilter = true;

        // alias for replacing 'x-enumNames' in swagger document
        o.XEnumNamesAlias = "x-enum-varnames";

        // alias for replacing 'x-enumDescriptions' in swagger document
        o.XEnumDescriptionsAlias = "x-enum-descriptions";

        // add parameter filter to fix enums (add 'x-enumNames' for NSwag or its alias from XEnumNamesAlias) in schema parameters
        o.ApplyParameterFilter = true;

        // add document filter to fix enums displaying in swagger document
        o.ApplyDocumentFilter = true;

        // new line for enum values descriptions
        o.NewLine = "\n";
    });
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ValidateModelAttribute());
}).ConfigureApiBehaviorOptions(options => {
    options.SuppressModelStateInvalidFilter = true;
}).AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<DatabaseContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
    options.UseNpgsql(connectionString);
});

builder.Services.AddDbContext<FilesContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
    options.UseNpgsql(connectionString);
});

builder.Services.AddTransient<IFileLoaderService, FileLoaderService>();
builder.Services.AddScoped<JwtTokenHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", x => { x.Response.Redirect("/index.html"); return Task.CompletedTask; });
app.UseStaticFiles();
app.UseRouting();

//Самые важные 5 строк кода
app.UseCors(builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

//app.UseAuthentication();
//app.UseAuthorization();
app.UseEndpoints(e => { });

//app.MapGet("/", async x => await x.Response.WriteAsync("Hello, world [GET]"));
//app.MapPost("/", async x => await x.Response.WriteAsync("Hello, world [POST]"));

app.MapControllers();

app.Run();
