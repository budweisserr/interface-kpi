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
        }

        private void LoadData()
        {
            using (var context = new DBTestEntities())
            {
                // Завантаження даних з таблиці Books
                var booksData = context.Books.ToList();
                BooksDataGrid.ItemsSource = booksData;

                // Завантаження даних з таблиці Publishers
                var publishersData = context.Publishers.ToList();
                PublishersDataGrid.ItemsSource = publishersData;
            }
        }
    }
}
