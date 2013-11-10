namespace Wpf.MessageOverlay.Commands
{
    using System;
    using System.Windows.Input;

    public interface IObservableCommand<T> : ICommand, IObservable<T>, IDisposable
    {
        bool CanExecute();
        bool CanExecute(T parameter);

        void Execute();
        void Execute(T parameter);

        void RaiseCanExecuteChanged();
    }
}