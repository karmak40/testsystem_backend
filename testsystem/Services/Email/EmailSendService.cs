using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Interfaces.Email;
using testsystem.Interfaces.Internal.Mail;

namespace testsystem.Services.Email
{
    public class EmailSendService : IEmailSendService
    {
        private readonly IEmailSender _emailSender;

        public EmailSendService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendMailAction()
        {
            await _emailSender.SendEmailAsync("snikers333london@mail.ru", "subject", $"this is a link to test. Please follow this link: www.google.com ");
        }
    }
}
