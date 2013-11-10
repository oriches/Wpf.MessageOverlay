namespace Wpf.MessageOverlay.ViewModels
{
    using System;
    using System.Reactive.Disposables;
    using Extensions;

    public sealed class MessageMonitor : Monitor, IMessageMonitor
    {
        private readonly SerialDisposable _closeDisposable;

        private IMessageViewModel _message;

        public MessageMonitor()
        {
            _closeDisposable = new SerialDisposable()
                .DisposeWith(this);
        }

        public bool HasMessage { get { return _message != null; } }

        public IMessageViewModel Message
        {
            get
            {
                return _message;
            }

            set
            {
                if (SetPropertyAndNotify(ref _message, value, () => Message))
                {
                    _closeDisposable.Disposable = _message.CloseCommand
                        .Subscribe(_ =>
                            {
                                _message.Dispose();
                                _message = null;

                                RaisePropertyChanged(() => HasMessage);
                            });

                    RaisePropertyChanged(() => HasMessage);
                }
            }
        }
    }
}