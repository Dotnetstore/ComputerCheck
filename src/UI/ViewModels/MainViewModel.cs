using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels;

internal sealed class MainViewModel : ObservableObject, IMainViewModel
{
    public IRelayCommand CloseApplicationCommand { get; set; }

    public MainViewModel()
    {
        CloseApplicationCommand = new RelayCommand(CloseApplication);
    }

    private static void CloseApplication()
    {
        var result = System.Windows.MessageBox.Show(
            "Are you sure you want to close the application?", 
            "Close Application", 
            System.Windows.MessageBoxButton.YesNo, 
            System.Windows.MessageBoxImage.Question);
        
        if (result == System.Windows.MessageBoxResult.Yes)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}