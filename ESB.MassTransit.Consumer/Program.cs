using ESB.MassTransit.Consumer.Consumers;
using MassTransit;

string rabbitMQUri = "amqps://bdzjjgtj:VIpygVbH8U3fwuk91GYnd1TCngLbCNdV@sparrow.rmq.cloudamqp.com/bdzjjgtj";
string queueName = "example-queue";
IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory => { factory.Host(rabbitMQUri); factory.ReceiveEndpoint(queueName, endpoint => { endpoint.Consumer<ExampleMessageConsumer>(); }); });

await bus.StartAsync();

Console.Read();

