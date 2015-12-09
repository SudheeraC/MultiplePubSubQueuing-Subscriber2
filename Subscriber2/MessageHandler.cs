using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Subscriber2
{
    class SecondMessageHandler : IHandleMessages<Two>
    {
        public void Handle(Two message)
        {
           Console.WriteLine("Subscriber2+" + message.message);
            //throw new NotImplementedException();
        }
    }
}
