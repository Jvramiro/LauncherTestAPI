using LauncherTestAPI.Data;
using LauncherTestAPI.Services;
using NCrontab;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LauncherContext>();
builder.Services.AddSingleton<Scheduler>();
builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scheduler = app.Services.GetRequiredService<Scheduler>();
scheduler.Start();

app.Run();
