using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
	public class Admin
	{
		[Key] 
		public int Id { get; set; }
		public User User { get; set; }

        [Required(ErrorMessage = "E-mail boş bırakılamaz.")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-]+)(\\.[a-zA-Z]{2,5}){1,2}$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Authority { get; set; }
	}
}
