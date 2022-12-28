using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Title { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
