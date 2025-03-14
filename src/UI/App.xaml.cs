using System.Windows;
using UI.ViewModels;
using UI.Views;

namespace UI;

public partial class App
{
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        IMainViewModel mainViewModel = new MainViewModel();
        var mainView = new MainView { DataContext = mainViewModel };
        mainView.Show();
    }
}