using LibraryManagment.Views.Windows;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManagment.Views.UserControls
{
    /// <summary>
    /// Interaction logic for BookList.xaml
    /// </summary>
    public partial class BookList : UserControl
    {
        public BookList()
        {
            InitializeComponent();
        }

        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_addBook_Click(object sender, RoutedEventArgs e)
        {

            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Owner = gk;
            gk.Opacity = 0.3;
            addBookWindow.ShowDialog();

        }
    }
}   
