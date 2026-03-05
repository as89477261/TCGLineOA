using Microsoft.AspNet.SignalR;

namespace CustomerHealthCheck
{
    public class SignalHub : Hub
    {
        public void send1(string userName)
        {
            // Broad cast message  
            var hub = GlobalHost.ConnectionManager.GetHubContext("SignalHub");
            hub.Clients.All.Send("11111");
        }

        public void send(string uid, string message, string transID)
        {
            // send to caller  
            var hub = GlobalHost.ConnectionManager.GetHubContext("SignalHub");
            hub.Clients.All.Send(uid, message, transID);
        }
    }
}