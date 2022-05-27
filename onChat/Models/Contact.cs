using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace onChat.Models
{
    public class Contact
    {
        // id = username
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        [Key]
        public string server { get; set; }
        public string last { get; set; }
        public string lastdate { get; set; }
    }
}
