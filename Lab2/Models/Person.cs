using System;
using System.ComponentModel.DataAnnotations;
using Oliinyk_Lab2.Tools;

namespace Oliinyk_Lab2.Models
{
    internal class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;

        public bool IsAdult
        {
            get { return _isAdult; }
        }

        public string SunSign
        {
            get { return _sunSign; }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname
        {
            get { return _surname; }
            private set { _surname = value; }
        }

        [Required]
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        [Required]
        [Birthday]
        public DateTime Birthday
        {
            get { return _birthday; }
            private set { _birthday = value; }
        }

        public Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
            _isAdult = BirthdayDate.IsAdult(_birthday);
            _chineseSign = BirthdayDate.ChineseSign(_birthday);
            _sunSign = BirthdayDate.SunSign(_birthday);
            _isBirthday = BirthdayDate.IsBirthday(_birthday);
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }
    }
}
