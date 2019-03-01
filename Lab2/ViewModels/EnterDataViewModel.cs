using Oliinyk_Lab2.Tools;
using Oliinyk_Lab2.Models;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Threading;
using Oliinyk_Lab2.Tools.Managers;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Oliinyk_Lab2.Tools.Navigation;

namespace Oliinyk_Lab2.ViewModels
{
    internal class EnterDataViewModel : BaseViewModel
    {
        private RelayCommand<object> _proceedCommand;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand= 
                           new RelayCommand<object>(ProceedImplementation, CanProceedExecute));
            }
        }

        internal void CleanAll()
        {
            Name = null;
            Email = null;
            Surname = null;
            Birthday = DateTime.Now;
        }

        private bool CanProceedExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_name) && !String.IsNullOrWhiteSpace(_surname) && !String.IsNullOrWhiteSpace(_email);
        }

        private async void ProceedImplementation(object obj)
        {
            Person person = new Person(Name, Surname, Email, Birthday);
            bool good = true;
            LoaderManeger.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                var results = new List<ValidationResult>();
                var context = new ValidationContext(person);
                if (!Validator.TryValidateObject(person, context, results, true))
                {
                    good = false;
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
            });
            LoaderManeger.Instance.HideLoader();
            if(good)  NavigationManager.Instance.Navigate(ViewType.ShowInformation, person);
        }

    }
}
