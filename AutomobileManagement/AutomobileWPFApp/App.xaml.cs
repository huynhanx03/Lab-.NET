using Microsoft.Extensions.DependencyInjection;
using AutomobileLibrary.Repository;
using System.Windows;

namespace AutomobileWPFApp
{
	public partial class App : Application
	{
		private ServiceProvider serviceProvider;

		public App()
		{
			// Config for Dependency Injection (DI)
			ServiceCollection services = new ServiceCollection();
			ConfigureServices(services);
			serviceProvider = services.BuildServiceProvider();
		}

		// Configures the services and adds them to the DI container
		private void ConfigureServices(ServiceCollection services)
		{
			services.AddSingleton(typeof(ICarRepository), typeof(CarRepository));
			services.AddSingleton<WindowCarManagement>();
		}

		// On application startup, opens the main window
		protected void OnStartup(object sender, StartupEventArgs e)
		{
			var windowCarManagement = serviceProvider.GetService<WindowCarManagement>();
			windowCarManagement.Show();
		}
	}
}
