namespace Wpf.MessageOverlay.ViewModels
{
    using Commands;

    public interface IHeaderViewModel : IViewModel
    {
        IObservableCommand ClickCommand { get; }

        int? Duration { get; set; }
    }
}