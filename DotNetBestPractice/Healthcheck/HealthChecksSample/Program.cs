//https://docs.microsoft.com/ko-KR/azure/architecture/patterns/health-endpoint-monitoring

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
