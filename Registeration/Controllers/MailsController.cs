using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Registeration.Data;
using Registeration.Models;
using Registeration.Utilities;

namespace Registeration.Controllers
{
    public class MailsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IEmailSender _emailSender;


        public MailsController(AppDBContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MailView mail)
        {
            if (ModelState.IsValid)
            {
                Mail newMail = new Mail();
                if (mail.File != null)
                {
                    if (mail.File.Length > 0)
                    {
                        var fileName = Path.GetFileName(mail.File.FileName);
                       
                        var fileExtension = Path.GetExtension(fileName);
                      
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                      
                        using (var target = new MemoryStream())
                        {
                            mail.File.CopyTo(target);
                            newMail.FileType = fileExtension;
                            newMail.Name = newFileName;
                            newMail.DataFile = target.ToArray();
                        }

                    }
                }
               await _emailSender.SendEmailAsync(
                mail.Email,
                mail.Subject,
                mail.Body,
                mail.File);
              
                newMail.Email = mail.Email;
                newMail.Body = mail.Body;
                newMail.Subject = mail.Subject;
             
                _context.Add(newMail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(mail);
        }

     
    }
}
