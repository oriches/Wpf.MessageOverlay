namespace Wpf.MessageOverlay.ViewModels
{
    using System;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Subjects;
    using Services;

    public abstract class Monitor : Bindable, ICompositeDisposable
    {
        private readonly CompositeDisposable _compositeDisposable;
        private readonly Subject<Unit> _isDisposing;

        protected Monitor()
        {
            _compositeDisposable = new CompositeDisposable();
            _isDisposing = new Subject<Unit>();
        }

        public bool IsDiposed { get; private set; }

        public IObservable<Unit> IsDisposing { get { return _isDisposing; } }

        public virtual void Dispose()
        {
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