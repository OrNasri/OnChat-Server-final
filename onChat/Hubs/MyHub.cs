using Microsoft.AspNetCore.SignalR;

namespace onChat.Hubs
{
    
    public class MyHub : Hub
    {
        public static List<Tuple<String, String>> OnlineUsers = new List<Tuple<String, String>>();
        public async Task SendMessage(string to, string from)
        {
            Tuple<String, String> user = new Tuple<String, String>(null, null);
           foreach(var lst in OnlineUsers)
            {
                if(lst.Item1 == to)
                {
                    user = lst;
                }
            }
            await Clients.All.SendAsync("ReceiveMessage",to, from );
          //    await Clients.Client(user.Item2).SendAsync("ReceiveMessage");
        }

        public async Task AddContact(string to)
        {
            Tuple<String, String> user = new Tuple<String, String>(null, null);
            foreach (var lst in OnlineUsers)
            {
                if (lst.Item1 == to)
                {
                    user = lst;
                }
            }
            await Clients.All.SendAsync("ReceiveContact",to);
           //  await Clients.Client(user.Item2).SendAsync("ReceiveContact");
        }

        public async Task DeclareOnline(string username)
        {
            OnlineUsers.Add(new Tuple<String, String>(username, Context.ConnectionId.ToString()));
        }

        public async Task LogOut(string username)
        {
            OnlineUsers.RemoveAll(e => e.Item1 == username);
        }

    }
}
