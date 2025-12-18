using LibraryManagment.Data;
using LibraryManagment.ViewModels;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace LibraryManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            this.DataContext = viewModel;

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                DatabaseConnection.ConnectionTest();
                Debug.WriteLine("Database bağlantısı başarılı");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Database hatası: {ex.Message}");
                MessageBox.Show($"Veritabanı bağlantısı kurulamadı: {ex.Message}",
                    "Bağlantı Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}