using System.Windows;

namespace UI.UserControlTemplates;

public partial class ThreeColGridTemplate
{
    public ThreeColGridTemplate()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty DataTextProperty = DependencyProperty.Register(
        nameof(DataText), typeof(string), typeof(ThreeColGridTemplate), new PropertyMetadata(default(string)));

    public string DataText
    {
        get => (string)GetValue(DataTextProperty);
        set => SetValue(DataTextProperty, value);
    }

    public static readonly DependencyProperty DataValueProperty = DependencyProperty.Register(
        nameof(DataValue), typeof(string), typeof(ThreeColGridTemplate), new PropertyMetadata(default(string)));

    public string DataValue
    {
        get => (string)GetValue(DataValueProperty);
        set => SetValue(DataValueProperty, value);
    }
}