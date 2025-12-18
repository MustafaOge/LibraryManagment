using LibraryManagment.Commands;
using LibraryManagment.Services;
using LibraryManagment.Views.UserControls;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagment.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private short _currentMenuSelect = 1;
        private bool _isMenuExpanded = true;
        private double _menuWidth = 220;
        private double _hamburgerWidth = 100;
        private Visibility _menuLabelsVisibility = Visibility.Visible;
        private Visibility _menuBottomVisibility = Visibility.Visible;

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Navigation Commands
            NavigateToBookListCommand = new RelayCommand(_ => NavigateToBookList());
            NavigateToMemberListCommand = new RelayCommand(_ => NavigateToMemberList());
            NavigateToLoanListCommand = new RelayCommand(_ => NavigateToLoanList());
            NavigateToOverdueListCommand = new RelayCommand(_ => NavigateToOverdueList());
            NavigateToSettingsCommand = new RelayCommand(_ => NavigateToSettings());
            NavigateToAboutCommand = new RelayCommand(_ => NavigateToAbout());

            // Window Commands
            CloseCommand = new RelayCommand(_ => Application.Current.MainWindow?.Close());
            MinimizeCommand = new RelayCommand(_ => MinimizeWindow());
            MaximizeCommand = new RelayCommand(_ => MaximizeWindow());
            ToggleMenuCommand = new RelayCommand(_ => ToggleMenu());

            // Uygulama açılınca default sayfa
            NavigateToBookList();
        }

        // Properties
        public INavigationService NavigationService => _navigationService;

        public short CurrentMenuSelect
        {
            get => _currentMenuSelect;
            set
            {
                _currentMenuSelect = value;
                OnPropertyChanged();
                UpdateMenuCheckedStates();
            }
        }

        public bool IsMenuExpanded
        {
            get => _isMenuExpanded;
            set
            {
                _isMenuExpanded = value;
                OnPropertyChanged();
            }
        }

        public double MenuWidth
        {
            get => _menuWidth;
            set
            {
                _menuWidth = value;
                OnPropertyChanged();
            }
        }

        public double HamburgerWidth
        {
            get => _hamburgerWidth;
            set
            {
                _hamburgerWidth = value;
                OnPropertyChanged();
            }
        }

        public Visibility MenuLabelsVisibility
        {
            get => _menuLabelsVisibility;
            set
            {
                _menuLabelsVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility MenuBottomVisibility
        {
            get => _menuBottomVisibility;
            set
            {
                _menuBottomVisibility = value;
                OnPropertyChanged();
            }
        }

        // Menu Checked States
        public bool IsBookListChecked => CurrentMenuSelect == 1;
        public bool IsMemberListChecked => CurrentMenuSelect == 2;
        public bool IsLoanListChecked => CurrentMenuSelect == 3;
        public bool IsOverdueListChecked => CurrentMenuSelect == 4;
        public bool IsSettingsChecked => CurrentMenuSelect == 5;
        public bool IsAboutChecked => CurrentMenuSelect == 6;

        // Navigation Commands
        public ICommand NavigateToBookListCommand { get; }
        public ICommand NavigateToMemberListCommand { get; }
        public ICommand NavigateToLoanListCommand { get; }
        public ICommand NavigateToOverdueListCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand NavigateToAboutCommand { get; }

        // Window Commands
        public ICommand CloseCommand { get; }
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand ToggleMenuCommand { get; }

        // Navigation Methods
        private void NavigateToBookList()
        {
            CurrentMenuSelect = 1;
            _navigationService.NavigateTo<BookList>();
        }

        private void NavigateToMemberList()
        {
            CurrentMenuSelect = 2;
            // _navigationService.NavigateTo<MemberList>();
        }

        private void NavigateToLoanList()
        {
            CurrentMenuSelect = 3;
            // _navigationService.NavigateTo<LoanList>();
        }

        private void NavigateToOverdueList()
        {
            CurrentMenuSelect = 4;
            // _navigationService.NavigateTo<OverdueList>();
        }

        private void NavigateToSettings()
        {
            CurrentMenuSelect = 5;
            // _navigationService.NavigateTo<Settings>();
        }

        private void NavigateToAbout()
        {
            CurrentMenuSelect = 6;
            // _navigationService.NavigateTo<About>();
        }

        // Window Methods
        private void MinimizeWindow()
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
        }

        private void MaximizeWindow()
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.WindowState =
                    Application.Current.MainWindow.WindowState == WindowState.Maximized
                        ? WindowState.Normal
                        : WindowState.Maximized;
            }
        }

        private void ToggleMenu()
        {
            if (IsMenuExpanded)
            {
                MenuWidth = 80;
                HamburgerWidth = 60;
                MenuLabelsVisibility = Visibility.Hidden;
                MenuBottomVisibility = Visibility.Hidden;
            }
            else
            {
                MenuWidth = 220;
                HamburgerWidth = 100;
                MenuLabelsVisibility = Visibility.Visible;
                MenuBottomVisibility = Visibility.Visible;
            }
            IsMenuExpanded = !IsMenuExpanded;
        }

        private void UpdateMenuCheckedStates()
        {
            OnPropertyChanged(nameof(IsBookListChecked));
            OnPropertyChanged(nameof(IsMemberListChecked));
            OnPropertyChanged(nameof(IsLoanListChecked));
            OnPropertyChanged(nameof(IsOverdueListChecked));
            OnPropertyChanged(nameof(IsSettingsChecked));
            OnPropertyChanged(nameof(IsAboutChecked));
        }
    }
}