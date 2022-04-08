using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Core.domain
{
    public interface IConsumerService : IDisposable
    {
        Task Start();
        void Stop();
    }
}
