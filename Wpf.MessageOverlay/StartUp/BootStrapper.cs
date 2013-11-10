namespace Wpf.MessageOverlay.StartUp
{
    using Autofac;
    using Services;
    using ViewModels;

    public static class BootStrapper
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get { return _container ?? (_container = Start()); }
        }

        private static IContainer Start()
        {
            var builder = new ContainerBuilder();

            // Configuration & Infrastructure...
            builder.RegisterType<SchedulerService>().As<ISchedulerService>().InstancePerLifetimeScope();

            // ViewModels...
            builder.RegisterType<BusyMonitor>().As<IBusyMonitor>().InstancePerLifetimeScope();
            builder.RegisterType<MessageMonitor>().As<IMessageMonitor>().InstancePerLifetimeScope();

            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<HeaderViewModel>().As<IHeaderViewModel>();
            builder.RegisterType<ContentViewModel>().As<IContentViewModel>();
            builder.RegisterType<ContentMessageViewModel>().As<IContentMessageViewModel>();
            builder.RegisterType<FooterViewModel>().As<IFooterViewModel>();

            return builder.Build();
        }
    }
}