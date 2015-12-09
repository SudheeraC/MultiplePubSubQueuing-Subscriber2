using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
namespace Shared
{
    public class Two : IEvent
    {
        public string message { get; set; }
    }
}
