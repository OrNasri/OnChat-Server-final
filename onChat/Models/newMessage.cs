using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace onChat.Models
{
    public class newMessage
    {
        [Required]
        public string content { get; set; }
    }
}