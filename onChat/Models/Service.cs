namespace onChat.Models
{
    public class Service
    {
        public static List<User> usersList = new List<User>{new User()
        {
            id = "or",
            nickname = "orush",
            password = "Nn123456",
            image = "https://bootdey.com/img/Content/avatar/avatar3.png",
            contacts = new List<Contact>
                { new Contact { id = "noa", name = "noale", server = "localhost:7242", last = "hiii", lastdate = "12:14" },
                { new Contact { id = "bob", name = "bobi", server = "localhost:7242", last = "hi love", lastdate = "10:10" }} },
            chats = new List<Chat>
                { new Chat { username = "noa",
                             messages = new List<Message>
                                { new Message {id = "1", content="how are you?", created = "12:02", sent = true },
                                new Message {id = "2", content="hiii", created = "12:14", sent = false }}},
                {new Chat { username = "bob",
                            messages = new List<Message>
                            { new Message {id = "9", content="hi love", created = "10:10", sent = true },
                }} }
            }},
        { new User()
        {
            id = "dani",
            nickname = "div",
            password = "Nn123456",
            image = "https://bootdey.com/img/Content/avatar/avatar6.png",
            contacts = new List<Contact>
            { new Contact { id = "noa", name = "noale", server = "localhost:7242", last = "see you", lastdate = "14:15" }},
            chats = new List<Chat> { new Chat {
                username = "noa",
                messages = new List<Message> { new Message {id = "7", content=":)", created = "14:10", sent = false },
                new Message {id = "8", content="see you", created = "14:15", sent = false }} }} }},

        { new User()
        {
            id = "bob",
            nickname = "bobi",
            password = "Nn123456",
            image = "https://bootdey.com/img/Content/avatar/avatar2.png",
            contacts = new List<Contact>
                { new Contact { id = "or", name = "orush",
                    server = "localhost:7242", last = "hi love", lastdate = "10:10" } },
             chats = new List<Chat> { new Chat {
                username = "or",
                messages = new List<Message> { new Message {id = "9", content="hi love", created = "10:10", sent = false }
                } }
        } } },
        { new User()
        {
            id = "noa",
            nickname = "noale",
            password = "Nn123456",
            image = "https://bootdey.com/img/Content/avatar/avatar8.png",
            contacts = new List<Contact>
                {new Contact { id = "or", name = "orush", server = "localhost:7242", last = "hiii", lastdate = "12:14" },
                new Contact { id = "dani", name = "div",server = "localhost:7242", last = "see you", lastdate = "14:15" } },
             chats = new List<Chat> {
                 new Chat {
                    username = "dani",
                    messages = new List<Message> { new Message {id = "7", content=":)", created = "14:10", sent = true },
                    new Message {id = "8", content="see you", created = "14:15", sent = true }}},
                 new Chat {
                     username = "or",
                    messages = new List<Message> { new Message {id = "1", content="how are you?", created = "12:02", sent = false },
                             new Message {id = "2", content="hiii", created = "12:14", sent = true }}} } } } };
        public List<User> GetAll()
        {
            return usersList;
        }
    }
}
