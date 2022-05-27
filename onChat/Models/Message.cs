using System.ComponentModel.DataAnnotations;
namespace onChat.Models
{
    public class Message
    {
        //id = Data
        [Key]
        //[Required]
        public string id { get; set; }
        public string content { get; set; }
        public string created { get; set; }
        public bool sent { get; set; }
    }
}
