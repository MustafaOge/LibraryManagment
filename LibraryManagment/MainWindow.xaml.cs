using LibraryManagment.Data;
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
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;   
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlHelper.AddToGrid(ContentArea, new BookList());
            DatabaseConnection.ConnectionTest();
            //Version.Content = DatabaseConnection.ConnState;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                grd_MainGridWindow.Margin = new Thickness(0, 0, 0, 0);

            }
            else
            {
                this.WindowState = WindowState.Maximized;
                grd_MainGridWindow.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        private void btn_hambuergerMenu_Click(object sender, RoutedEventArgs e)
        {
            if (btn_hambuergerMenu.Width != 60)
            {
                grdColumn_menu.Width = new GridLength(80, GridUnitType.Pixel);

                lbl_menu1.Visibility = Visibility.Hidden;
                lbl_menu2.Visibility = Visibility.Hidden;
                lbl_menu3.Visibility = Visibility.Hidden;
                lbl_menu4.Visibility = Visibility.Hidden;
                lbl_menu5.Visibility = Visibility.Hidden;
                lbl_menu6.Visibility = Visibility.Hidden;

                lbl_logotitle.Width = 0;
                btn_hambuergerMenu.Width = 60;
                menu_bottom_border.Visibility = Visibility.Hidden;
                menu_bottom_window_image.Visibility = Visibility.Hidden;
            }
            else
            {
                grdColumn_menu.Width = new GridLength(220, GridUnitType.Pixel);

                lbl_menu1.Visibility = Visibility.Visible;
                lbl_menu2.Visibility = Visibility.Visible;
                lbl_menu3.Visibility = Visibility.Visible;
                lbl_menu4.Visibility = Visibility.Visible;
                lbl_menu5.Visibility = Visibility.Visible;
                lbl_menu6.Visibility = Visibility.Visible;

                lbl_logotitle.Width = 150;
                btn_hambuergerMenu.Width = 100;
                menu_bottom_border.Visibility = Visibility.Visible;
                menu_bottom_window_image.Visibility = Visibility.Visible;
            }
        }



    }
}