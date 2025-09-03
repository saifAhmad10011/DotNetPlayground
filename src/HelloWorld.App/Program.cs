using HelloWorld.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HelloService>();

var app = builder.Build();

app.MapGet("/hello/{name}", (HelloService svc, string name) => svc.GetMessage(name));

app.Run();
