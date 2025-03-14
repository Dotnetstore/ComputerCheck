using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace UI.Views;

public partial class InfoCardView
{
    public InfoCardView()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(InfoCardView), new PropertyMetadata(default(string)));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty NumberProperty = DependencyProperty.Register(
        nameof(Number), typeof(string), typeof(InfoCardView), new PropertyMetadata(default(string)));

    public string Number
    {
        get => (string)GetValue(NumberProperty);
        set => SetValue(NumberProperty, value);
    }

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(PackIconKind), typeof(InfoCardView), new PropertyMetadata(default(PackIconKind)));

    public PackIconKind Icon
    {
        get => (PackIconKind)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly DependencyProperty Background1Property = DependencyProperty.Register(
        nameof(Background1), typeof(Color), typeof(InfoCardView), new PropertyMetadata(default(Color)));

    public Color Background1
    {
        get => (Color)GetValue(Background1Property);
        set => SetValue(Background1Property, value);
    }

    public static readonly DependencyProperty Background2Property = DependencyProperty.Register(
        nameof(Background2), typeof(Color), typeof(InfoCardView), new PropertyMetadata(default(Color)));

    public Color Background2
    {
        get => (Color)GetValue(Background2Property);
        set => SetValue(Background2Property, value);
    }

    public static readonly DependencyProperty EllipseBackground1Property = DependencyProperty.Register(
        nameof(EllipseBackground1), typeof(Color), typeof(InfoCardView), new PropertyMetadata(default(Color)));

    public Color EllipseBackground1
    {
        get => (Color)GetValue(EllipseBackground1Property);
        set => SetValue(EllipseBackground1Property, value);
    }

    public static readonly DependencyProperty EllipseBackground2Property = DependencyProperty.Register(
        nameof(EllipseBackground2), typeof(Color), typeof(InfoCardView), new PropertyMetadata(default(Color)));

    public Color EllipseBackground2
    {
        get => (Color)GetValue(EllipseBackground2Property);
        set => SetValue(EllipseBackground2Property, value);
    }
}