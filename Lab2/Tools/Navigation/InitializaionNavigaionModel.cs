using System;
using Oliinyk_Lab2.Models;
using Oliinyk_Lab2.Tools.Navigation;
using EnterDataView = Oliinyk_Lab2.Views.EnterDataView;
using ShowInformationView = Oliinyk_Lab2.Views.ShowInformationView;

namespace Oliinyk_Lab2Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType, Person person)
        {
            if(ViewsDictionary.ContainsKey(viewType)) ViewsDictionary.Remove(viewType);
            switch (viewType)
            {
                case ViewType.EnterData:
                    ViewsDictionary.Add(viewType, new EnterDataView());
                    break;
                case ViewType.ShowInformation:
                    ViewsDictionary.Add(viewType, new ShowInformationView(person));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
