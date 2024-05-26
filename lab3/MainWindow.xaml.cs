using System;
using System.Windows;
using System.Windows.Navigation;

namespace lab3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.frame1.Focus();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            frame1.Navigate(new Uri(e.Uri.ToString(), UriKind.Relative));
        }
    }
}
