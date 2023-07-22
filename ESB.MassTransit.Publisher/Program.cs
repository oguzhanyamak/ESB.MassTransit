using ESB.MassTransit.Shared.Messages;
using MassTransit;

string rabbitMQUri = "amqps://bdzjjgtj:VIpygVbH8U3fwuk91GYnd1TCngLbCNdV@sparrow.rmq.cloudamqp.com/bdzjjgtj";
string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory => { factory.Host(rabbitMQUri); });

ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(new($"{rabbitMQUri}/{queueName}"));



Console.Write("Gönderilecek Mesaj :");
string message = Console.ReadLine();

await sendEndpoint.Send<IMessage>(new ExampleMessage(){Text = message});

Console.ReadKey();