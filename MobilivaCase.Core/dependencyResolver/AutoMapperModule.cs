using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject.Modules;

namespace MobilivaCase.Core.DependencyResolver
{
    public class AutoMapperModule : NinjectModule
    {
        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override void Load()
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            Bind<IMapper>().ToConstant(CreateConfiguration().CreateMapper()).InSingletonScope();
        }

        [Obsolete]
        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles((IEnumerable<Profile>)GetType().Assembly);
            });
            return config;
        }
    }
}

