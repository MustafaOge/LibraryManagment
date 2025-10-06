using LibraryManagment.Services;
using LibraryManagment.Views.UserControls;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void top_border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menubutton_booklist_Click(object sender, RoutedEventArgs e)
        {
            UserControlHelper.AddToGrid(ContentArea, new BookList());
        }
    }
}