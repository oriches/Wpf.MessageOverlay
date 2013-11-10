namespace Wpf.MessageOverlay.ViewModels
{
    public interface IMainViewModel : IViewModel
    {
        IViewModel HeaderPane { get; }

        IViewModel ContentPane { get; }

        IViewModel FooterPane { get; }
    }
}