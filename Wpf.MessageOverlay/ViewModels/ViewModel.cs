namespace Wpf.MessageOverlay.ViewModels
{
    using System;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Subjects;

    public abstract class ViewModel : Bindable, IViewModel, IMonitorsViewModel
    {
        private readonly IBusyMonitor _busyMonitor;
        private readonly IMessageMonitor _messageMonitor;
        private readonly CompositeDisposable _compositeDisposable;
        private readonly Subject<Unit> _isDisposing;

        protected ViewModel(IBusyMonitor busyMonitor = null, IMessageMonitor messageMonitor = null)
        {
            _busyMonitor = busyMonitor ?? new BusyMonitor();
            _messageMonitor = messageMonitor ?? new MessageMonitor();

            _compositeDisposable = new CompositeDisposable();

            _isDisposing = new Subject<Unit>();
        }
        
        public bool IsDiposed { get; private set; }

        public IObservable<Unit> IsDisposing { get { return _isDisposing; } }

        public IBusyMonitor BusyMonitor { get { return _busyMonitor; } }

        public IMessageMonitor MessageMonitor { get { return _messageMonitor; } }

        public virtual void Dispose()
        {
            if (IsDiposed)
            {
                return;
            }

            IsDiposed = true;

            _isDisposing.OnNext(Unit.Default);
            _isDisposing.Dispose();

            _compositeDisposable.Dispose();
        }

        public void Add(IDisposable disposable)
        {
            _compositeDisposable.Add(disposable);
        }
    }
}