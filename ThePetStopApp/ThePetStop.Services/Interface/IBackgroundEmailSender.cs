using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThePetStop.Services.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
