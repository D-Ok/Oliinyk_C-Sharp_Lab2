using Oliinyk_Lab2.Models;

namespace Oliinyk_Lab2.Tools.Navigation
{
    internal enum ViewType
    {
        EnterData,
        ShowInformation
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType, Person person);
    }
}
