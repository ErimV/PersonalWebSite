using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "İsim boş bırakılamaz.")]
		public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim boş bırakılamaz.")]
        public string Surname { get; set; }
		[Required(ErrorMessage = "Ünvan boş bırakılamaz.")]
		public string Title { get; set; }
        [Required(ErrorMessage = "E-mail boş bırakılamaz.")]
		[RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-]+)(\\.[a-zA-Z]{2,5}){1,2}$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
	}
}
