namespace Wpf.MessageOverlay.Services
{
    using System.Reactive.Concurrency;

    public sealed class SchedulerService : ISchedulerService
    {
        public IScheduler Dispatcher
        {
            get { return DispatcherScheduler.Current; }
        }

        public IScheduler TaskPool
        {
            get { return TaskPoolScheduler.Default; }
        }

        public IScheduler Immediate
        {
            get { return ImmediateScheduler.Instance; }
        }
    }
}