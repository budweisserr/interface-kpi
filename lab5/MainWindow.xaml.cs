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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            LoadPublishersWithBookCount();
        }

        private void LoadData()
        {
            using (var context = new DBTestEntities())
            {
                var booksData = context.Books.ToList();
                BooksDataGrid.ItemsSource = booksData;

                var publishersData = context.Publishers.ToList();
                PublishersDataGrid.ItemsSource = publishersData;
            }
        }

        private void LoadPublishersWithBookCount()
        {
            using (var context = new DBTestEntities())
            {
                var publishersBookCount = context.Publishers
                                                  .Select(p => new
                                                  {
                                                      PublisherName = p.PublisherName,
                                                      BookCount = p.Books.Count
                                                  })
                                                  .ToList();
                PublishersBookCountDataGrid.ItemsSource = publishersBookCount;
            }
        }

        private void SearchBooksByAuthor_Click(object sender, RoutedEventArgs e)
        {
            string author = AuthorTextBox.Text;
            using (var context = new DBTestEntities())
            {
                var booksByAuthor = context.Books
                                           .Where(b => b.Author == author)
                                           .ToList();
                BooksByAuthorDataGrid.ItemsSource = booksByAuthor;
            }
        }

        private void SearchBooksByYear_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(YearTextBox.Text, out int year))
            {
                using (var context = new DBTestEntities())
                {
                    var booksByYear = context.Books
                                             .Where(b => b.Year == year)
                                             .ToList();
                    BooksByYearDataGrid.ItemsSource = booksByYear;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid year.");
            }
        }
    }
}
