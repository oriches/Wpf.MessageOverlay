namespace Wpf.MessageOverlay.ViewModels
{
    using System;
    using Commands;
    using Extensions;

    public sealed class ContentViewModel : ViewModel, IContentViewModel
    {
        private readonly Func<string, IContentMessageViewModel> _contentMessageFunc;

        public ContentViewModel(Func<string, IContentMessageViewModel> contentMessageFunc,
            IBusyMonitor busyMonitor,
            IMessageMonitor messageMonitor)
            : base(busyMonitor, messageMonitor)
        {
            _contentMessageFunc = contentMessageFunc;

            Message = "This is an example message...";

            ClickCommand = new ObservableCommand(ExecuteClick)
                .DisposeWith(this);
        }

        public string Message { get; set; }

        public IObservableCommand ClickCommand { get; private set; }

        private void ExecuteClick()
        {
            MessageMonitor.Message = _contentMessageFunc(Message);
        }
    }
}