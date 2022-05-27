using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace onChat.Models
{
    public class Login
    {
        // id = username
        [Key]
        [Required]
        public string id { get; set; }
        [Required]
        public string password { get; set; }


    }

}