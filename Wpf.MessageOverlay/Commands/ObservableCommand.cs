namespace Wpf.MessageOverlay.Commands
{
    using System;
    using System.Reactive;

    public sealed class ObservableCommand : ObservableCommand<Unit>, IObservableCommand
    {
        public ObservableCommand() : this(null, null)
        {
        }

        public ObservableCommand(Action execute) : base(u => execute(), null)
        {
        }

        public ObservableCommand(Action execute, Func<bool> canExecute)
            : base(u => SafeExecute(execute), u => SafeExecute(canExecute))
        {
        }

        private static void SafeExecute(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        private static bool SafeExecute(Func<bool> func)
        {
            return func == null || func();
        }
    }
}