using LibraryManagment.Data;
using LibraryManagment.Repositories;
using LibraryManagment.Services;
using LibraryManagment.ViewModels;
using LibraryManagment.Views.UserControls;
using LibraryManagment.Views.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace LibraryManagment
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build(); 

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Postgres")));

            // Repositories
            services.AddScoped<IBookRepository, BookRepository>();

            // Services
            services.AddAutoMapper(typeof(AutoMapper.MapperProfile));
            services.AddScoped<IBookService, BookService>();
            services.AddSingleton<INavigationService, NavigationService>();


            // ViewModels
            services.AddTransient<MainWindowViewModel>(); 
            services.AddTransient<BookListViewModel>();

            // Views/Windows
            services.AddSingleton<MainWindow>();
            services.AddTransient<BookList>();
            services.AddTransient<AddBookWindow>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
            base.OnExit(e);
        }
    }
}