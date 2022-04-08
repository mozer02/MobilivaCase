using MobilivaCase.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Core.domain
{
    public interface IPublisherService
    {
        void Enqueue(MailMessageData queueDataModels, string queueName);
    }
}
