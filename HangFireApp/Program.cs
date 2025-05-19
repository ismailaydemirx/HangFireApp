using Hangfire;
using HangFireApp.Context;
using HangFireApp.Controller;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add services to the container.
// 1- set up hangfire libraries then
// hangfire options to record SQL
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);
});
// register hangfire service
builder.Services.AddHangfireServer();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// active hangfire dashboard
app.UseHangfireDashboard();

// scheduled job, hangfire can work with sync or async methods.
RecurringJob.AddOrUpdate("test-print-job", () => BackgroundTestServices.HangFireWorks(), Cron.MinuteInterval(19));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
