using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManagment.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCloseBookItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1;
        }

        private void btnBookItemInfo_Click(object sender, RoutedEventArgs e)
        {
            // Buraya bilgi butonuna tıklandığında yapılacak işlemleri yazabilirsin
            MessageBox.Show("Book info button clicked!");
        }

    }
}
