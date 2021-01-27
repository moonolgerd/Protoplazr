using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protoplazr
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var item = new PayloadItem()
            {
                Id = 1,
                Message = "Hello One"
            };
            var reply = new HelloReply
            {
                Message = "Hello " + request.Name
            };
            reply.Items.Add(item);
            return Task.FromResult(reply);
        }
    }
}
