using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMiddleware.Models
{
    public class LogSensitivity
    {        
        public bool logErrors { get; set; }
        public bool logRequests { get; set; }
        public bool logResponses { get; set; }
        public bool logResponseStatus { get; set; }
    }
}
