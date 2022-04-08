using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilivaCase.Core.domain;
using Ninject.Modules;

namespace MobilivaCase.Core.DependencyResolver
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRabbitMQService>().To<RabbitMQService>().InSingletonScope();
            Bind<IRabbitMQConfiguration>().To<RabbitMQConfiguration>().InSingletonScope();
            Bind<IObjectConvertFormat>().To<ObjectConvertFormatManager>().InSingletonScope();
        }
    }
}

