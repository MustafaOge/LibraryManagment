namespace LibraryManagment.Model
{
    public class BookListModel
    {
        public string Barcode { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string BookType { get; set; }
        public string AuthorFullName { get; set; } = null!;
        public string AcquisitionType { get; set; }
        public DateTimeOffset? AcquisitionDate { get; set; }
        public string PublisherName { get; set; } = null!;
        public DateTimeOffset? PrintDate { get; set; }
        public bool IsLoaned { get; set; }
    }
}
