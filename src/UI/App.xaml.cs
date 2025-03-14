using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using UI.ViewModels;
using UI.Views;

namespace UI;

public partial class App
{
    private IMainViewModel _mainViewModel = null!;
    private MainView _mainView = null!;
    
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        AddServices();
        RunApplication();
    }

    private void AddServices()
    {
        IServiceCollection services = new ServiceCollection();
        
        services
            .AddScoped<IMainViewModel, MainViewModel>()
            .AddScoped<IInfoCardViewModel, InfoCardViewModel>()
            .AddScoped<IDashboardViewModel, DashboardViewModel>()
            .AddTransient<DashboardView>()
            .AddTransient<InfoCardView>()
            .AddTransient<MainView>();
        
        var serviceProvider = services.BuildServiceProvider();
        _mainViewModel = serviceProvider.GetRequiredService<IMainViewModel>();
        _mainView = serviceProvider.GetRequiredService<MainView>();
    }
    
    private void RunApplication()
    {
        _mainView.DataContext = _mainViewModel;
        _mainView.Show();
    }
}