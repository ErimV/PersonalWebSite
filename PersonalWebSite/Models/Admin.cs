﻿using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Models
{
	public class Admin
	{
		[Key] 
		public int Id { get; set; }
		public User User { get; set; }
		public string Authority { get; set; }
	}
}
