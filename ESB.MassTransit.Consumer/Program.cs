using ESB.MassTransit.Consumer.Consumers;
using ESB.MassTransit.Shared.Const;
using MassTransit;

string rabbitMQUri = Variables.uri;
string queueName = "example-queue";
IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory => { factory.Host(rabbitMQUri); factory.ReceiveEndpoint(queueName, endpoint => { endpoint.Consumer<ExampleMessageConsumer>(); }); });

await bus.StartAsync();

Console.Read();

