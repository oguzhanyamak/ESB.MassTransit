﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.MassTransit.Shared.Messages
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
       
    }
}
