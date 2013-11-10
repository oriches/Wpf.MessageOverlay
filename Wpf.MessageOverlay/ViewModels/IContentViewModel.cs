namespace Wpf.MessageOverlay.ViewModels
{
    using Commands;

    public interface IContentViewModel : IViewModel
    {
        string Message { get; set; }

        IObservableCommand ClickCommand { get; }
    }
}