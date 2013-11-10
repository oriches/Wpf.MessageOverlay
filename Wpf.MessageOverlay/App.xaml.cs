namespace Wpf.MessageOverlay
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using Autofac;
    using Helpers;
    using StartUp;
    using ViewModels;

    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            UIHelper.Freeze(TimeSpan.FromMilliseconds(500))
                    .Subscribe(ts => Debug.WriteLine("UI Freeze: {0} ms", ts.TotalMilliseconds));

            var viewModel = BootStrapper.Container.Resolve<IMainViewModel>();

            new MainWindow
                {
                    DataContext = viewModel,
                }.Show();
        }
    }
}