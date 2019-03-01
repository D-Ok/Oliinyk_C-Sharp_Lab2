using System.Windows.Controls;
using Oliinyk_Lab2.Models;
using Oliinyk_Lab2.Tools.Navigation;
using Oliinyk_Lab2.ViewModels;

namespace Oliinyk_Lab2.Views
{
    /// <summary>
    /// Логика взаимодействия для ShowInformationView.xaml
    /// </summary>
    public partial class ShowInformationView : UserControl, INavigatable
    {
        internal ShowInformationView(Person person)
        {
            InitializeComponent();
            DataContext = new ShowInformationViewModel(person);
        }
    }
}
