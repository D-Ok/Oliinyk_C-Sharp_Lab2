using System.Windows.Controls;
using Oliinyk_Lab2.Tools.Navigation;
using Oliinyk_Lab2.ViewModels;

namespace Oliinyk_Lab2.Views
{
    /// <summary>
    /// Логика взаимодействия для EnterData.xaml
    /// </summary>
    public partial class EnterDataView : UserControl,INavigatable
    {
        public EnterDataView()
        {
            InitializeComponent();
            DataContext = new EnterDataViewModel();
        }
    }
}
