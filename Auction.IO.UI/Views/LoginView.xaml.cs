using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Auction.IO.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {

        public ICommand LoginCommand
        {
            get { return (ICommand)GetValue(LoginCommandProperty); }
            set { SetValue(LoginCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(LoginView), new PropertyMetadata(null));



        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, System.Windows.RoutedEventArgs e)
        {
            string password = pbPassword.Password;

            if (LoginCommand != null)
                LoginCommand.Execute(password);
        }
    }
}
