using ESB.MassTransit.RequestResponsePattern.Consumer.Consumer;
using ESB.MassTransit.Shared.Const;
using MassTransit;

string rabbitMQUri = Variables.uri;
string queueName = "request-queue";
Console.Write("Consumer \n");
IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory => { factory.Host(rabbitMQUri); factory.ReceiveEndpoint(queueName, endpoint => { endpoint.Consumer<RequestMessageConsumer>(); }); });

await bus.StartAsync();

Console.Read();