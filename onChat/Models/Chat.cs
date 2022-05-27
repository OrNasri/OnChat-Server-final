using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace onChat.Models
{
    public class Chat
    {
        [Key]
        public string username { get; set; }
        public List<Message> messages { get; set; }

    }
}
