using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Redstone.Data;
using Redstone.Data.Services;
using Redstone.Desktop.Controls;
using Redstone.Desktop.Customers;
using Redstone.Desktop.Profiles;
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
                cfg.AddProfile(new AddressProfile());
            });
            // Automapper
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            // Controls
            services.AddSingleton<IDialogService, DialogService>();
            // Data Repository
            services.AddSingleton<RedstoneDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            // View Models
            services.AddScoped<MainViewModel>();
            services.AddScoped<CustomerViewModel>();
            services.AddScoped<AddCustomerViewModel>();
            services.AddScoped<EditCustomerViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow window = _serviceProvider.GetService<MainWindow>();
            window.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();
        }
    }
}
