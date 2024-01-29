using Microsoft.EntityFrameworkCore;
using Portal.Core.Interfaces;
using Portal.Core.Models;
using Portal.Core.Repositories;
using Portal.Services;
using Portal.Services.Interfaces;
using System.Diagnostics;
using AutoMapper;
using ActivityPortal.API.Mapping;
using Microsoft.AspNetCore.Hosting;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("constring");


// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<ActivityPortalContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ActivityPortalContext>();

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddScoped<IGuideEventRepository, GuidesEventRepository>();
builder.Services.AddScoped<IGuideEventService, GuideEventService>();

builder.Services.AddScoped<IMemberEventRepository, MembersEventRepository>();
builder.Services.AddScoped<IMemberEventService, MemberEventService>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IGuideRepository, GuideRepository>();
builder.Services.AddScoped<IGuideService, GuideService>();

builder.Services.AddScoped<IUserRoleRepository, UsersRoleRepository>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

builder.Services.AddScoped<ILookupRepository, LookupRepository>();
builder.Services.AddScoped<ILookupService, LookupService>();

builder.Services.AddScoped<IWebsiteInformationRepository, WebsiteInformationRepository>();
builder.Services.AddScoped<IWebInformationService, WebsiteInformationService>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
