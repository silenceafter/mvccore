using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Hosting;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using homeWork9.Models;
using homeWork9.Repositories;
using homeWork9.Repositories.Interfaces;
using homeWork9.Services;
using homeWork9.Services.Interfaces;
using homeWork9;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddDbContext<MessageContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=messagesdb;Username=postgres;Password=bdw"));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Message}/{action=Index}/{id?}");
app.Run();