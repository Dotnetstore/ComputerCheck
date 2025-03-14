using System.Windows.Input;

namespace UI.Views;

public partial class MainView
{
    public MainView()
    {
        InitializeComponent();
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }
}