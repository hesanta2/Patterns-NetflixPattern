using Application;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _AddMicroservice.DependencyInyection.Modules
{
    public class ApplicationServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddService>()
                .As<IAddService>()
                .InstancePerLifetimeScope();
        }
    }
}
