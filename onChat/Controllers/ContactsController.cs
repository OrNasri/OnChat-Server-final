using Microsoft.AspNetCore.Mvc;
using onChat.Models;

namespace onChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        public static int indexId = 10;
        private Service service;
        List<User> usersList = new List<User>();
        private readonly ILogger<ContactsController> _logger;
        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
            service = new Service();
            usersList = service.GetAll();
        }

        [HttpGet]
        public List<User> Index()
        {
            return usersList;
        }

        [HttpPost("{id}")]
        public IActionResult GetLogin(string id, [Bind("id, password")] Login login)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id && usersList[i].password == login.password)
                {
                    return Ok(usersList[i]);
                }
            }
            return NotFound();
        }

        [HttpPost()]
        public IActionResult SignUp([Bind("id, nickname, password")] User user)
        {
            if (usersList.Select(x => x.id).Contains(user.id))
            {
                return BadRequest();
            }
            user.image = "https://bootdey.com/img/Content/avatar/avatar4.png";
            user.chats = new List<Chat>();
            user.contacts = new List<Contact>();
            usersList.Add(user);
            return Ok(usersList);
        }

        [HttpGet("{user}")]
        public IActionResult GetContactsListByUser(string user)

        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == user)
                {
                    return Ok(usersList[i].contacts);

                }
            }
            return NotFound();
        }

        [HttpGet("{id}/contacts")]
        public IActionResult GetContactList(string id)
        {

            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id)
                {
                    return Ok(usersList[i].contacts);
                }
            }
            return NotFound();
        }

        [HttpGet("{user}/contacts/{id}")]
        public IActionResult GetContact(string user, string id)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == user)
                {
                    for (int j = 0; j < usersList[i].contacts.Count; j++)
                    {
                        if (usersList[i].contacts[j].id == id)
                        {
                            return Ok(usersList[i].contacts[j]);
                        }
                    }
                }
            }
            return NotFound();
        }


        [HttpPost("{id}/contacts/")]
        public IActionResult Create(string id, [Bind("id, name, server")] AddContact contact)
        {
            Contact contact2 = new Contact();
            contact2.last = null;
            contact2.lastdate = null;
            contact2.id = contact.id;
            contact2.name = contact.name;
            contact2.server = contact.server;
            Chat chat = new Chat();
            chat.username = contact2.id;
            chat.messages = new List<Message>();
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id)
                {
                    usersList[i].contacts.Add(contact2);
                    usersList[i].chats.Add(chat);
                    return StatusCode(201);
                }
            }
            return NotFound();
        }

        [HttpPut("{id1}/contacts/{id2}")]
        public IActionResult Edit(string id1, string id2, [Bind("name, server")] PutContact contact)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id1)
                {
                    for (int j = 0; j < usersList[i].contacts.Count; j++)
                    {
                        if (usersList[i].contacts[j].id == id2)
                        {
                            usersList[i].contacts[j].name = contact.name;
                            usersList[i].contacts[j].server = contact.server;
                            return StatusCode(204);
                        }
                    }
                }
            }
            return NotFound();
        }

        [HttpDelete("{id1}/contacts/{id2}")]
        public IActionResult Delete(string id1, string id2)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id1)
                {
                    for (int j = 0; j < usersList[i].contacts.Count; j++)
                    {
                        if (usersList[i].contacts[j].id == id2)
                        {
                            usersList[i].contacts.RemoveAt(j);
                            usersList[i].chats.RemoveAt(j);
                            return StatusCode(204);
                        }
                    }
                }
            }
            return NotFound();
        }

        [HttpGet("{id1}/contacts/{id2}/messages")]
        public IActionResult GetMessages(string id1, string id2)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id1)
                {
                    for (int j = 0; j < usersList[i].chats.Count; j++)
                    {
                        if (usersList[i].chats[j].username == id2)
                        {
                            return Ok(usersList[i].chats[j].messages);
                        }
                    }
                }
            }
            return NotFound();
        }

        [HttpGet("{id1}/contacts/{id2}/messages/{id3}")]
        public IActionResult GetMessageById(string id1, string id2, string id3)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id1)
                {
                    for (int j = 0; j < usersList[i].chats.Count; j++)
                    {
                        if (usersList[i].chats[j].username == id2)
                        {
                            for (int k = 0; k < usersList[i].chats[j].messages.Count; k++)
                            {
                                if (usersList[i].chats[j].messages[k].id == id3)
                                {
                                    return Ok(usersList[i].chats[j].messages[k]);
                                }

                            }
                        }
                    }
                }
            }
            return NotFound();
        }
        [HttpDelete("{id1}/contacts/{id2}/messages/{id3}")]
        public IActionResult DeleteMessageById(string id1, string id2, string id3)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id1)
                {
                    for (int j = 0; j < usersList[i].chats.Count; j++)
                    {
                        if (usersList[i].chats[j].username == id2)
                        {
                            for (int k = 0; k < usersList[i].chats[j].messages.Count; k++)
                            {
                                if (usersList[i].chats[j].messages[k].id == id3)
                                {
                                    usersList[i].chats[j].messages.RemoveAt(k);
                                    return StatusCode(204);
                                }

                            }
                        }
                    }
                }
            }
            return NotFound();
        }


        [HttpPost("{id1}/contacts/{id2}/messages")]
        public IActionResult AddMessageById(string id1, string id2, [Bind("content")] newMessage message)
        {
            Message newMessage = new Message();
            newMessage.id = indexId.ToString();
            newMessage.content = message.content;
            indexId++;
            DateTime time = DateTime.Now;
            string format = "HH:mm";
            newMessage.created = time.ToString(format);
            newMessage.sent = true;

            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id1)
                {
                    for (int j = 0; j < usersList[i].chats.Count; j++)
                    {
                        for (int k = 0; k < usersList[i].contacts.Count; k++)
                        {
                            if (usersList[i].contacts[k].id == id2)
                            {
                                usersList[i].contacts[k].last = newMessage.content;
                                usersList[i].contacts[k].lastdate = newMessage.created;
                            }
                        }
                        if (usersList[i].chats[j].username == id2)
                        {
                            usersList[i].chats[j].messages.Add(newMessage);
                            return StatusCode(201);
                        }
                    }
                }
            }
            return NotFound();
        }

        [HttpPut("{id1}/contacts/{id2}/messages/{id3}")]
        public IActionResult EditMessage(string id1, string id2, string id3, string content)
        {
            DateTime time = DateTime.Now;
            string format = "HH:mm";
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].id == id1)
                {
                    for (int j = 0; j < usersList[i].chats.Count; j++)
                    {
                        if (usersList[i].chats[j].username == id2)
                        {
                            for (int k = 0; k < usersList[i].chats[j].messages.Count; k++)
                            {
                                if (usersList[i].chats[j].messages[k].id == id3)
                                {
                                    usersList[i].chats[j].messages[k].content = content;
                                    usersList[i].chats[j].messages[k].created = time.ToString(format);

                                    for (int t = 0; t < usersList[i].contacts.Count; t++)
                                    {
                                        if (usersList[i].contacts[t].id == id2)
                                        {
                                            usersList[i].contacts[t].lastdate = time.ToString(format);
                                        }
                                    }
                                    return StatusCode(204);
                                }

                            }
                        }
                    }
                }
            }
            return NotFound();
        }

    }
}