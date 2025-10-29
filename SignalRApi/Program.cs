using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.BusinessLayer.Container;
using SignalR.BusinessLayer.ValidationRules.BookingValidations;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntityLayer.Entities;
using SignalRApi.Hubs;
using SignalRApi.Mapping;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// CORS ayarları
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();

builder.Services.AddSignalR();
// SignalR servisini ekle

// Diğer servisler
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(typeof(ProductMapping));

// Scoped servisler
builder.Services.ContainerDependencies();

//validations
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();



builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Swagger ayarları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Restoran API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restoran API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
