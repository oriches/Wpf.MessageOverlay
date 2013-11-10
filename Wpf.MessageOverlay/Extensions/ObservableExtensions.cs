namespace Wpf.MessageOverlay.Extensions
{
    using System;
    using Services;

    public static class ObservableExtensions
    {
        public static T DisposeWith<T>(this T source, ICompositeDisposable disposable) where T : IDisposable
        {
            disposable.Add(source);
            return source;
        }
    }
}