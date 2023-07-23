using ESB.MassTransit.Shared.RequestResponseMessage;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.MassTransit.RequestResponsePattern.Consumer.Consumer
{
    public class RequestMessageConsumer : IConsumer<RequestMessage>
    {
        string[] response = {"Başarılı", "Başarısız"};
        public async Task Consume(ConsumeContext<RequestMessage> context)
        {
            Random rnd = new Random();
            int number = rnd.Next(2);
            Console.WriteLine($"Mesaj Geldi Id : {context.RequestId} cevap gönderildi \n");
            await context.RespondAsync<ResponseMessage>(new ResponseMessage() { Text = response[number] });

        }
    }
}
