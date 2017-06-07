using Sample.UWP.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Sample.UWP
{
public class PersonItemDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate PersonStandardTemplate { get; set; }
    public DataTemplate PersonVIPTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        FrameworkElement element = container as FrameworkElement;

        if (element != null && item != null && item is Person)
        {
            Person person = item as Person;

            if (person.Id % 2 == 0)
                return PersonStandardTemplate;
            else
                return PersonVIPTemplate;
        }

        return null;
    }
}
}
