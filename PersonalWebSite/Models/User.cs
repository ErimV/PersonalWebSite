using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage ="First Name is required.")]
		public string Name { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string Surname { get; set; }
		public string Title { get; set; }
        [Required(ErrorMessage = "Email is required.")]
		[RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-]+)(\\.[a-zA-Z]{2,5}){1,2}$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
	}
}
