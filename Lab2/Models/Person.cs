﻿using System;
using System.ComponentModel.DataAnnotations;
using Oliinyk_Lab2.Tools.Exceptions;

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

        public string Name
        {
            get { return _name; }
            private set
            {
                if (value.Length < 3) throw new TooShortNameException("This name is too short");
                else _name = value;
            }
        }
        
        public string Surname
        {
            get { return _surname; }
            private set
            {
                if (value.Length < 3) throw new TooShortSurnameException("This surname is too short");
                else _surname = value;
            }
        }
        
        public string Email
        {
            get { return _email; }
            private set
            {
                if (!IsEmail(value)) throw new UncorrectEmailException("This e-mail can not exis.");
                else _email = value;
            }
        }
        
        public DateTime Birthday
        {
            get { return _birthday; }
            private set
            {
               if (BirthdayDate.IsFutureBirthday(value)) throw new FutureBirthdayException("This person has not been born yet.");
               else if (BirthdayDate.IsPastBirthday((value))) throw new PastBirthdayException("This person is too old to be alive.");
               else _birthday = value;
            }
        }

        public Person(string name, string surname, string email, DateTime birthday)
        {
                Name = name;
                Surname = surname;
                Email = email;
                Birthday = birthday;
                _isAdult = BirthdayDate.IsAdult(_birthday);
                _chineseSign = BirthdayDate.ChineseSign(_birthday);
                _sunSign = BirthdayDate.SunSign(_birthday);
                _isBirthday = BirthdayDate.IsBirthday(_birthday);
        }

        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.Today)
        {
        }
        
        public Person(string name, string surname, DateTime birthday) : this(name, surname, "smth@smth.com", DateTime.Today)
        {
        }

        //перевірка, чи вірна адреса електронної пошти
        internal static bool IsEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
        
    }
}
