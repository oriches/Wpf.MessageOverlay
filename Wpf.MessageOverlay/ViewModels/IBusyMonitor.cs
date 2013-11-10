namespace Wpf.MessageOverlay.ViewModels
{
    using System;

    public interface IBusyMonitor : IBindable, IDisposable
    {
        bool IsBusy { get; set; }
    }
}