using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
	public class Admin
	{
		[Key] 
		public int Id { get; set; }
		public User User { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-]+)(\\.[a-zA-Z]{2,5}){1,2}$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Authority { get; set; }
	}
}
