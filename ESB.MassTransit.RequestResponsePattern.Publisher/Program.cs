using ESB.MassTransit.Shared.Const;
using ESB.MassTransit.Shared.RequestResponseMessage;
using MassTransit;

string rabbitMQUri = Variables.uri;
string queueName = "request-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory => { factory.Host(rabbitMQUri); });

await bus.StartAsync();

var request = bus.CreateRequestClient<RequestMessage>(new Uri($"{rabbitMQUri}/{queueName}"));
Console.Write("Publisher \n");

int i = 1;
while (true)
{
    await Task.Delay(10000);
    Console.WriteLine("İstek Gönderiliyor \n");
    var response = await request.GetResponse<ResponseMessage>(new() { MessageNo = i, Text = $"{i}. Mesaj isteği gönderildi \n"});
    i++;
    Console.WriteLine($"{response.RequestId} için cevap alındı Durum : {response.Message.Text}\n");
}