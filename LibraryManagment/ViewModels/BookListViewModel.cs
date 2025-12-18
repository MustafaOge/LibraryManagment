using LibraryManagment.Commands;
using LibraryManagment.Data.Entities;
using LibraryManagment.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagment.ViewModels
{
    public class BookListViewModel : BaseViewModel
    {
        private readonly IBookService _bookService;
        private bool _isLoading;
        private string _errorMessage;

        public BookListViewModel(IBookService bookService)
        {
            _bookService = bookService;
            Books = new ObservableCollection<Book>();

            LoadBooksCommand = new RelayCommand(async _ => await LoadBooksAsync());
            RefreshCommand = new RelayCommand(async _ => await LoadBooksAsync());
            AddBookCommand = new RelayCommand(_ => OpenAddBookWindow());

            _ = LoadBooksAsync();
        }

        // Properties
        public ObservableCollection<Book> Books { get; }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasError));
            }
        }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        // Commands
        public ICommand LoadBooksCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand AddBookCommand { get; }

        // Methods
        private async Task LoadBooksAsync()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                Debug.WriteLine("Kitaplar yükleniyor...");

                var books = await _bookService.GetAllAsync();

                Books.Clear();
                foreach (var book in books)
                {
                    Books.Add(book);
                }

                Debug.WriteLine($"{Books.Count} kitap yüklendi");
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Kitaplar yüklenirken hata oluştu: {ex.Message}";
                Debug.WriteLine($"Hata: {ex.Message}");

                MessageBox.Show(ErrorMessage, "Hata",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void OpenAddBookWindow()
        {
            Debug.WriteLine("AddBookWindow açılıyor...");
        }
    }
}