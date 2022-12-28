using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
	public class Image
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
