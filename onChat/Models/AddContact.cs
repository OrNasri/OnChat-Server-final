using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace onChat.Models
{
    public class AddContact
    {
        // id = username
        [Key]
        [Required]
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string server { get; set; }

    }

}
