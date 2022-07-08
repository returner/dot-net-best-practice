using Grpc.Net.Client;
using GrpcGreet;

using var channel = GrpcChannel.ForAddress("https://localhost:7078");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
Console.WriteLine($"Greeting : {reply.Message}");