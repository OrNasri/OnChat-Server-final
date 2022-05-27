using System.ComponentModel.DataAnnotations;

namespace onChat.Models
{
    public class User
    {
        // id = username
        [Key]
        public string id { get; set; }
        //[Required]
        public string nickname { get; set; }

        // [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        //[Required]
        public string image { get; set; }
        //[Required]
        public List<Contact> contacts { get; set; }
        //[Required]
        public List<Chat> chats { get; set; }

    }
}
