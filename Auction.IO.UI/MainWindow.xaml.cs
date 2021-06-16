using System.Windows;

namespace Auction.IO.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object dataContext)
        {
            InitializeComponent();

            this.DataContext = dataContext;
        }
    }
}
