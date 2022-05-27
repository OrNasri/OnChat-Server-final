using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace onChat.Models
{
    public class AddContactInvitation
    {
        [Key]
        [Required]
        public string from { get; set; }
        [Required]
        public string to { get; set; }
        [Required]
        public string server { get; set; }
    }
}
