namespace Wpf.MessageOverlay.Helpers
{
    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;

    public static class UIHelper
{
    private static readonly TimeSpan Buffer = TimeSpan.FromMilliseconds(25);

    public static IObservable<TimeSpan> Freeze(TimeSpan interval)
    {
        var intervalWithBuffer = interval + Buffer;

        return Observable.Interval(interval, DispatcherScheduler.Current)
                         .TimeInterval(DispatcherScheduler.Current)
                         .Where(ti => ti.Interval > intervalWithBuffer)
                         .Select(ti => ti.Interval);
    }
}
}