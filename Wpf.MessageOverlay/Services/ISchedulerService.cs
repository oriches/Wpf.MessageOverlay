namespace Wpf.MessageOverlay.Services
{
    using System.Reactive.Concurrency;

    public interface ISchedulerService
    {
        IScheduler Dispatcher { get; }

        IScheduler TaskPool { get; }

        IScheduler Immediate { get; }
    }
}