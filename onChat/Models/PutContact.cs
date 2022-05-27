using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace onChat.Models
{
    public class PutContact
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string server { get; set; }
    }
}