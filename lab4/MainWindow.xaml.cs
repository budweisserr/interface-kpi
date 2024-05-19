using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace lab4
{
    public partial class MainWindow : Window
    {
        private DatabaseAccess databaseAccess;
        public DataView BooksTable { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            databaseAccess = new DatabaseAccess();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable booksTable = databaseAccess.GetBooks();
            if (booksTable != null && booksTable.Rows.Count > 0)
            {
                BooksTable = booksTable.DefaultView;
                listBooks.ItemsSource = BooksTable;
                listBooks.SelectedIndex = 0;
                listBooks.Focus();
            }
            else
            {
                MessageBox.Show("No data found in the Books table.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string isbn = txtISBN.Text;
                string name = txtName.Text;
                string author = txtAuthor.Text;
                string publisher = txtPublisher.Text;
                int year = int.Parse(txtYear.Text);

                databaseAccess.AddBook(isbn, name, author, publisher, year);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating book: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string isbn = txtISBN.Text;
                string name = txtName.Text;
                string author = txtAuthor.Text;
                string publisher = txtPublisher.Text;
                int year = int.Parse(txtYear.Text);

                databaseAccess.UpdateBook(isbn, name, author, publisher, year);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string isbn = txtISBN.Text;
                databaseAccess.DeleteBook(isbn);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshData()
        {
            DataTable booksTable = databaseAccess.GetBooks();
            BooksTable = booksTable.DefaultView;
            listBooks.ItemsSource = BooksTable;
            listBooks.SelectedIndex = 0;
            listBooks.Focus();
        }
    }
}
