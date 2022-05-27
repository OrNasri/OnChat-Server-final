using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using onChat.Models;
using onChat.Hubs;

namespace onChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transferController : Controller
    {
        private IHubContext<MyHub> hub;
        public static int indexId = 10;
        private Service service;
        List<User> usersList = new List<User>();
        public transferController(IHubContext<MyHub> hub)
        {
            service = new Service();
            usersList = service.GetAll();
            this.hub = hub;
        }

        [HttpPost()]
        public IActionResult Transfer([Bind(" from, to, content")] AddContactTransfer newContact)
        {
            Message message = new Message();
            message.content = newContact.content;
            message.id = indexId.ToString();
            indexId++;
            DateTime time = DateTime.Now;
            string format = "HH:mm";
            message.created = time.ToString(format);
            message.sent = false;
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == newContact.to)
                {
                    for (int j = 0; j < usersList[i].chats.Count; j++)
                    {
                        for (int k = 0; k < usersList[i].contacts.Count; k++)
                        {
                            if (usersList[i].contacts[k].id == newContact.from)
                            {
                                usersList[i].contacts[k].last = message.content;
                                usersList[i].contacts[k].lastdate = message.created;
                            }

                        }
                        if (usersList[i].chats[j].username == newContact.from)
                        {
                            usersList[i].chats[j].messages.Add(message);
                            hub.Clients.All.SendAsync("ReceiveMessage", newContact.to, newContact.from);
                            return StatusCode(201);
                        }
                    }
                }
            }
            return NotFound();
        }


    }
}