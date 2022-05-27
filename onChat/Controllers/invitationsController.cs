using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using onChat.Models;
using onChat.Hubs;
namespace onChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class invitationsController : Controller
    {
        private IHubContext<MyHub> hub;
        private Service service;
        List<User> usersList = new List<User>();
        public invitationsController(IHubContext<MyHub> hub)
        {
            service = new Service();
            usersList = service.GetAll();
            this.hub = hub;
        }

        [HttpPost()]
        public IActionResult invitations([Bind("from, to, server")] AddContactInvitation newContact)
        {
            Contact contact = new Contact();
            Chat chat = new Chat();
            chat.username = newContact.from;
            chat.messages = new List<Message>();
            contact.lastdate = "";
            contact.last = "";
            contact.server = newContact.server;
            contact.id = newContact.from;
            contact.name = newContact.from;
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == newContact.to)
                {
                    usersList[i].contacts.Add(contact);
                    usersList[i].chats.Add(chat);
                    hub.Clients.All.SendAsync("ReceiveContact", newContact.to);
                    return StatusCode(201);
                }
            }
            return NotFound();
        }

    }
}