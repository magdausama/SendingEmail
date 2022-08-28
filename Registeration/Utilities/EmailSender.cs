using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Registeration.Utilities
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        public async Task SendEmailAsync(string email, string subject, string body ,IFormFile file)
        {
            string content;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                content = Convert.ToBase64String(fileBytes);
            }

            MailjetClient client = new MailjetClient(_configuration["MailJet:ApiKey"], "MailJet:SecretKey");
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kerolssamer348@gmail.com")
            .Property(Send.FromName, "Magda")
            .Property(Send.Subject, subject)
            .Property(Send.HtmlPart, body)
            .Property(Send.Attachments, new JArray
            {
                new JObject {
                 {"Content-type", file.ContentType},
                 {"Filename", file.FileName},
                 {"content", content}
                 }
            })

            .Property(Send.Recipients, new JArray {
                new JObject {
                    {"Email", email}
                    }
                });
            var ret = await client.PostAsync(request);
        }


    }


    }
