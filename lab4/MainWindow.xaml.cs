﻿using System;
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

namespace lab4
{
    public partial class MainWindow : Window
    {
        private DatabaseAccess databaseAccess;

        public MainWindow()
        {
            InitializeComponent();
            databaseAccess = new DatabaseAccess();
            LoadData();
        }

        private void LoadData()
        {
            DataTable booksTable = databaseAccess.GetBooks();
            // Assuming you have a DataGrid named BooksDataGrid in your XAML
            BooksDataGrid.ItemsSource = booksTable.DefaultView;
        }
    }
}
