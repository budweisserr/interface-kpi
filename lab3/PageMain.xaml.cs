using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace lab3
{
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            NavigationService.Navigate(new Uri(e.Uri.ToString(), UriKind.Relative));
        }
    }
}
