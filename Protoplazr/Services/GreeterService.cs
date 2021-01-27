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

        public override async Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            for (var i = 0; i < 100; i++)
            {
                var item = new PayloadItem()
                {
                    Id = i,
                    Message = $"Hello {i}"
                };
                var reply = new HelloReply
                {
                    Message = "Hello " + request.Name
                };
                reply.Items.Add(item);
                await responseStream.WriteAsync(reply);

                await Task.Delay(1000);
            }
        }
    }
}
