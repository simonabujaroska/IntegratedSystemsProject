using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThePetStop.Domain.DomainModels;

namespace ThePetStop.Services.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
