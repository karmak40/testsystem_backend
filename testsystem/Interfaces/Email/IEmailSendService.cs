using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testsystem.Interfaces.Email
{
    public interface IEmailSendService
    {
        Task SendMailAction();
    }
}
