namespace Wpf.MessageOverlay.ViewModels
{
    using System.ComponentModel;
    using Services;

    public interface IViewModel : INotifyPropertyChanging, INotifyPropertyChanged, ICompositeDisposable
    {
    }
}