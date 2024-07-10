using gRPC.DbServiceApp.Services;
using Grpc.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();
var env = app.Environment;

app.MapGrpcService<ImageService>();

if (env.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.MapGet("/",
    () =>
        "gRPC-service of DB working...");

app.Run();