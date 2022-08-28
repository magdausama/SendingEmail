using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Registeration.Models
{
	public class Mail
	{
		public int Id { get; set; }

		public string Email { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }

		[MaxLength(100)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string FileType { get; set; }
		[MaxLength]
		public byte[] DataFile { get; set; }

	}
}
