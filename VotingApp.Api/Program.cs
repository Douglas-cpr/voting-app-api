using VotingApp.Application;
using VotingApp.Application.Persistence;
using VotingApp.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPollRepository, PollInMemRepository>();
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
