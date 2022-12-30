using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Can't leave blank comment")]
        public string Text { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserTitle { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
