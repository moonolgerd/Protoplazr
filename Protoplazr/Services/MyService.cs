using Protoplazr.Shared;
using System.Threading.Tasks;

namespace Protoplazr.Services
{
    public class MyService : IMyService
    {
        public Task<MyServiceResult> DoSomething(MyServiceRequest request)
        {
            return Task.FromResult(new MyServiceResult()
            {
                NewText = request.Text + " from server",
                NewValue = request.Value + 1
            });
        }
    }
}
