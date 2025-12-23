using AutoMapper;
using LibraryManagment.Commands;
using LibraryManagment.Data.Entities;
using LibraryManagment.Model;
using LibraryManagment.Services;
using System.Collections.Generic;
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
        private readonly IMapper mapper;

        public BookListViewModel(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            Books = new ObservableCollection<BookListModel>();

            LoadBooksCommand = new RelayCommand(async _ => await LoadBooksAsync());
            RefreshCommand = new RelayCommand(async _ => await LoadBooksAsync());
            AddBookCommand = new RelayCommand(_ => OpenAddBookWindow());

            _ = LoadBooksAsync();
            this.mapper = mapper;
        }

        // Properties
        public ObservableCollection<BookListModel> Books { get; }

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

                var bookList = mapper.Map<List<BookListModel>>(books);
                Books.Clear();
                foreach (var book in bookList)
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