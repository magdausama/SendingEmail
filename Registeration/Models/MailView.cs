using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Registeration.Models
{
	public class MailView
	{
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public IFormFile File { get; set; }
	}
}
