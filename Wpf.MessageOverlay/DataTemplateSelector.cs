namespace Wpf.MessageOverlay
{
    using System.Windows;
    using ViewModels;

    public sealed class DataTemplateSelector : System.Windows.Controls.DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item != null && item is IViewModel)
            {
                var name = item.GetType().Name;

                var templateName = name.Replace("Model", "Template");
                return element.FindResource(templateName) as DataTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}