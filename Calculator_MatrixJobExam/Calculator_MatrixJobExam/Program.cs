using Calculator_MatrixJobExam.Extensions;
using Calculator_MatrixJobExam.Filters;
using Calculator_MatrixJobExam.Middlewares;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));//Allow to send enum names instead the values

builder.Services.AddJWTAuthorization(builder.Configuration);

builder.Services
    .AddMvc(options =>
    {
        options.InputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>();
        options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter>();
    })
    .AddNewtonsoftJson(opts =>
    {
        opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
    })
    .AddXmlSerializerFormatters();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1.0.0", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "Calculator API",
        Description = "Calculator API (ASP.NET Core 8.0)",
        Contact = new OpenApiContact()
        {
            Name = "Swagger Codegen Contributors",
            Url = new Uri("https://github.com/swagger-api/swagger-codegen"),
            Email = ""
        },
    });
    c.CustomSchemaIds(type => type.FullName);
    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{builder.Environment.ApplicationName}.xml");

    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
    c.OperationFilter<GeneratePathParamsValidationFilter>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//First, add the ExceptionHandlingMiddleware to catch any exceptions that occur during the request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Calculator API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
