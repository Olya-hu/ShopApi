using Autofac;
using Services;

namespace ShopApi
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServicesModule>();
        }
    }
}