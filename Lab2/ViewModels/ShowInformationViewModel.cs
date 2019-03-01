using Oliinyk_Lab2.Tools;
using System;
using System.Windows;
using Oliinyk_Lab2.Models;
using Oliinyk_Lab2.Tools.Managers;
using Oliinyk_Lab2.Tools.Navigation;

namespace Oliinyk_Lab2.ViewModels
{
    internal class ShowInformationViewModel: BaseViewModel
    {
        private RelayCommand<object> _backCommand;
        private string _name;
        private string _surname;
        private string _email;
        private string _birthday;
        private string _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private string _isBirthday;

        public string IsAdult
        {
            get { return _isAdult; }
            private set
            {
                _isAdult = value;
                OnPropertyChanged("IsAdult");
            }
        }

        public string SunSign
        {
            get { return _sunSign; }
            private set
            {
                _sunSign = value;
                OnPropertyChanged("SunSign");
            }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            private set
            {
                _chineseSign = value;
                OnPropertyChanged("ChineseSign");
            }
        }

        public string IsBirthday
        {
            get { return _isBirthday; }
            private set
            {
                _isBirthday = value;
                OnPropertyChanged("IsBirthday");
            }
        }
        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            private set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Email
        {
            get { return _email; }
            private set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Birthday
        {
            get { return _birthday; }
            private set
            {
                _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public ShowInformationViewModel(Person person)
        {
            InitializePerson(ref person);
            if (person.IsBirthday) MessageBox.Show(" Happy Birthday!!! ");
        }

        internal void InitializePerson(ref Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            Birthday = person.Birthday.ToShortDateString();
            if (person.IsBirthday) IsBirthday = "Today is your Birthday";
            else IsBirthday = "Today isn`t your Birthday";
            if (person.IsAdult) IsAdult = "You are adult";
            else IsAdult = "You are child";
            ChineseSign = person.ChineseSign;
            SunSign = person.SunSign;
        }
        

        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.EnterData, null);

                           }));
            }
        }

    }
}
