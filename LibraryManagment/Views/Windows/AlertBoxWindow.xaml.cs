using LibraryManagment.Data;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace LibraryManagment.Views.Windows
{
    /// <summary>
    /// Interaction logic for AlertBox.xaml
    /// </summary>
    public partial class AlertBox : Window
    {
        public AlertBox()
        {
            InitializeComponent();
        }

        private void btn_BilgiEkrani_Kapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;

            Hata();


        }

        void Hata()
        {
            if (Constants.error == 0)
            {
                Olumlu_BilgiEkrani.Visibility = Visibility.Visible;
                Olumsuz_BilgiEkrani.Visibility = Visibility.Hidden;
                img_Olumlu.Visibility = Visibility.Visible;
                img_Olumsuz.Visibility = Visibility.Hidden;
                BilgiEkrani_Content.Content = Constants.alertBoxContent;
                BilgiEkrani_Header.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF134187"));
                BilgiEkrani_Content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF134187"));

            }
            else
            {
                Olumlu_BilgiEkrani.Visibility = Visibility.Hidden;
                Olumsuz_BilgiEkrani.Visibility = Visibility.Visible;
                img_Olumlu.Visibility = Visibility.Hidden;
                img_Olumsuz.Visibility = Visibility.Visible;
                BilgiEkrani_Content.Content = Constants.alertBoxContent;
                BilgiEkrani_Header.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF4CAF50"));
                BilgiEkrani_Content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF4CAF50"));
            }


            ///  7 saniye sonra kapan

            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(7)
            };

            timer.Tick += delegate (object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                if (this.ShowActivated) this.Close();
            };

            timer.Start();

        }
    }
}
