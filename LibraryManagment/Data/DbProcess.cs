using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace LibraryManagment.Data
{
    public class DbProcess
    {
        public static bool FillGrid(DataGrid grd)
        {
            try
            {
                using (var con = new SqliteConnection(DatabaseConnection.DbConnection))
                {
                    con.Open();

                    using (var cmd = new SqliteCommand(@"
                    SELECT 
                        AUTHOR.FULL_NAME AS AuthorName,
                        BOOK.BARCODE,
                        BOOK.ID,
                        BOOK.BOOK_TYPE,
                        BOOK.DESCRIPTION,
                        BOOK.PRINT_LOCATION,
                        BOOK.PRINT_NUMBER,
                        BOOK.PRINT_DATE,
                        BOOK.ACQUISITION_TYPE,
                        BOOK.ACQUISITION_DATE,
                        BOOK.PAGE_COUNT,
                        BOOK.IMAGE,
                        BOOK.TITLE,
                        BOOK.IS_LOANED,
                        READER.FULL_NAME AS ReaderName,
                        READER.ID AS ReaderID
                    FROM BOOK
                    INNER JOIN PUBLISHER ON PUBLISHER.ID = BOOK.PUBLISHER_ID
                    INNER JOIN AUTHOR ON AUTHOR.ID = BOOK.AUTHOR_ID
                    LEFT JOIN LOAN ON LOAN.BOOK_ID = BOOK.ID AND LOAN.STATUS = 0 -- aktif ödünçler
                    LEFT JOIN READER ON READER.ID = LOAN.READER_ID;
                ", con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader); 

                        grd.ItemsSource = dt.DefaultView;

                        if (dt.Rows.Count > 0)
                        {
                            return dt.Rows.Count > 0;

                        }
                        return dt.Rows.Count > 0;
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı hatası:\n{ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
