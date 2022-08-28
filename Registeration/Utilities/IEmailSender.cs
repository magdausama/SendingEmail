using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Registeration.Utilities
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage, IFormFile file);

    }
}
