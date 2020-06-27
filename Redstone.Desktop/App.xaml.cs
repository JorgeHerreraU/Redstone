using Microsoft.Extensions.DependencyInjection;
using Redstone.Data;
using Redstone.Data.Services;
using Redstone.Desktop.Customers;
using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Redstone.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            // Data Repository
            services.AddSingleton<RedstoneDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            //services.AddSingleton<IRepository<Customer>, EntityFrameworkRepository<Customer>>();
            // View Models
            services.AddScoped<MainViewModel>();
            services.AddScoped<CustomerViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow window = _serviceProvider.GetService<MainWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();
        }
    }
}
