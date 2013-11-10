namespace Wpf.MessageOverlay.ViewModels
{
    using System;

    public interface IMessageMonitor : IBindable, IDisposable
    {
        bool HasMessage { get; }

        IMessageViewModel Message { get; set; }
    }
}