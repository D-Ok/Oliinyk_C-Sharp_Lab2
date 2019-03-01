using System.Windows;
using System.Windows.Controls;
using Oliinyk_Lab2.Tools.Managers;
using Oliinyk_Lab2.Tools.Navigation;
using Oliinyk_Lab2.ViewModels;
using Oliinyk_Lab2Tools.Navigation;

namespace Oliinyk_Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.EnterData, null);
        }
    }
}
