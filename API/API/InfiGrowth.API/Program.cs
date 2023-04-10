
using InfiGrowth.API.Infrastructure;
using InfiGrowth.Infra.Extensions;
using InfiGrowth.Services.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
// Add services to the container.


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    //.MinimumLevel.Warning()
    .Enrich.FromLogContext()
    //.WriteTo.File(Path.Combine("wwwroot\\Log", "skyttus_admin.txt"),
    //rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddMvc();
builder.Services.InfiGrowthInfraServiceRegistration(builder.Configuration);
builder.Services.InfiGrowthInfraService();
builder.Services.AddMemoryCache();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    })
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Default Policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.Use(async (context, next) =>
//{
//    await next();

//    if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
//    {
//        context.Response.Clear();
//        context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
//        //await context.Response.WriteAsync("401");
//        var jsonString = "{\"StatusCode\":"+ (int)System.Net.HttpStatusCode.Unauthorized + ",\"Messsage\":'Unauthorized'}";
//        byte[] data = Encoding.UTF8.GetBytes(jsonString);
//        context.Response.ContentType = "application/json";
//        await context.Response.Body.WriteAsync(data, 0, data.Length);
//    }
    
//});

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.UseStaticFiles();

app.Run();


