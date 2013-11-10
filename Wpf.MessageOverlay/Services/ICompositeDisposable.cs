namespace Wpf.MessageOverlay.Services
{
    using System;
    using System.Reactive;

    public interface ICompositeDisposable : IDisposable
    {
        IObservable<Unit> IsDisposing { get; }

        void Add(IDisposable disposable);

    }
}