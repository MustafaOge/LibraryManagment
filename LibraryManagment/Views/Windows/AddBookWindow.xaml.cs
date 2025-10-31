using LibraryManagment.Data;
using LibraryManagment.Enums;
using LibraryManagment.Helpers;
using System.Windows;
using System.Windows.Controls;

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

        private async void btnBookItemInfo_Click(object sender, RoutedEventArgs e)
        {
            SoundHelper.Play(SoundType.Popup);
            await PopupHelper.ShowPopupAsync(popup_info, 3000);
        }

        private void btn_book_add_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Constants.error = 0;
            Constants.alertBoxContent = "Kayıt İşlemi Başarılı";
            AlertBox be = new AlertBox();
            be.Show();

        }
    }
}
