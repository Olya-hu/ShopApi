using Autofac;
using Database;
using Services.Catalog;

namespace Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopContext>().AsSelf().SingleInstance();
            builder.RegisterType<CatalogService>().As<ICatalog>();
        }
    }
}
