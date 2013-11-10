namespace Wpf.MessageOverlay.Commands
{
    using System;
    using System.Reactive;
    using System.Windows.Input;

    public interface IObservableCommand : ICommand, IObservable<Unit>, IDisposable
    {
        bool CanExecute();

        void Execute();

        void RaiseCanExecuteChanged();
    }
}