namespace Wpf.MessageOverlay.ViewModels
{
    using System;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Commands;
    using Extensions;
    using Services;

    public sealed class HeaderViewModel : ViewModel, IHeaderViewModel
    {
        private readonly ISchedulerService _schedulerService;
        private readonly SerialDisposable _executeDisposable;

        private int? _duration;

        public HeaderViewModel(IBusyMonitor busyMonitor, ISchedulerService schedulerService)
            : base(busyMonitor)
        {
            _schedulerService = schedulerService;
           
            _executeDisposable = new SerialDisposable()
                .DisposeWith(this);

            Duration = 1000;

            ClickCommand = new ObservableCommand(ExecuteClick, () => Duration.HasValue)
                .DisposeWith(this);
        }

        public IObservableCommand ClickCommand { get; private set; }

        public int? Duration
        {
            get { return _duration; }
            
            set { SetPropertyAndNotify(ref _duration, value, () => Duration); }
        }

        private void ExecuteClick()
        {
            BusyMonitor.IsBusy = true;

            var absoluteTime = DateTimeOffset.Now.AddMilliseconds(Duration.Value);
            _executeDisposable.Disposable = Observable.Timer(absoluteTime, _schedulerService.TaskPool)
                                                      .ObserveOnDispatcher()
                                                      .Subscribe(_ => BusyMonitor.IsBusy = false);

        }
    }
}