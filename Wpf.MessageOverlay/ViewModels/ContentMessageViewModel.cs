namespace Wpf.MessageOverlay.ViewModels
{
    using System;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Commands;
    using Extensions;
    using Services;

    public sealed class ContentMessageViewModel : ViewModel, IContentMessageViewModel
{
    private readonly ISchedulerService _schedulerService;
    private readonly SerialDisposable _executeDisposable;

    public ContentMessageViewModel(string message, IBusyMonitor busyMonitor, ISchedulerService schedulerService)
        : base(busyMonitor)
    {
        _schedulerService = schedulerService;
        Message = message;

        _executeDisposable = new SerialDisposable()
            .DisposeWith(this);

        CloseCommand = new ObservableCommand()
            .DisposeWith(this);

        BusyAndCloseCommand = new ObservableCommand(MakeBusyThenClose)
            .DisposeWith(this);
    }

    public IObservableCommand CloseCommand { get; private set; }

    public IObservableCommand BusyAndCloseCommand { get; private set; }

    public string Message { get; private set; }

    private void MakeBusyThenClose()
    {
        BusyMonitor.IsBusy = true;

        var absoluteTime = DateTimeOffset.Now.AddMilliseconds(2000);
        _executeDisposable.Disposable = Observable.Timer(absoluteTime, _schedulerService.TaskPool)
                                                    .ObserveOnDispatcher()
                                                    .Subscribe(_ =>
                                                                {
                                                                    BusyMonitor.IsBusy = false;
                                                                    CloseCommand.Execute();
                                                                });
    }
}
}