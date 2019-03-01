using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Oliinyk_Lab2.Models
{
    internal static class BirthdayDate
    {

        private static string[] _chineseHoroscope = {"Monkey",  "Rooster", "Dog",  "Pig",
            "Rat", "Bul", "Tiger", "Rabbit","Dragon", "Snake","Horse",  "Sheep"   };

        private static string[] _westHoroscope =
        {
            "Aquarius", "Pisces",  "Aries", "Taurus" ,"Gemini" , "Cancer" ,
            "Leo" ,"Virgo" , "Libra","Scorpio" ,"Sagittarius" , "Capricorn"
        };

        private static int[] _westBeginDates = { 21, 21, 21, 21, 21, 22, 23, 24, 24, 24, 23, 22 };


        //обрахування знаку китайського гороскопу
        public static string ChineseSign(DateTime birthday)
        {
            return _chineseHoroscope[birthday.Year % 12];
        }

        //обрахування знаку західного гороскопу
        public static string SunSign(DateTime birthday)
        {
            if (birthday.Day < _westBeginDates[birthday.Month - 1])
            {
                if (birthday.Month == 1)
                    return _westHoroscope[11];
                else return _westHoroscope[birthday.Month - 2];
            }
            else return _westHoroscope[birthday.Month - 1];
        }

        //перевірка, чи введена дата народження правильна
        public static bool IsCorrectDateOfBirthday(DateTime birthday)
        {
            return (DateTime.Now > birthday && CalculateAge(birthday) < 135);
        }
        //обрахування віку
        public static int CalculateAge(DateTime birthday)
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate.Month > birthday.Month) return currentDate.Year - birthday.Year;
            else if (currentDate.Month == birthday.Month && currentDate.Day >= birthday.Day) return currentDate.Year - birthday.Year;
            else return currentDate.Year - birthday.Year - 1;
        }
        //перевірка, чи день народження сьогодні
        public static bool IsBirthday(DateTime birthday)
        {
            DateTime currentDate = DateTime.Now;
            return (currentDate.Month == birthday.Month && currentDate.Day == birthday.Day);
        }

        public static bool IsAdult(DateTime birthday)
        {
            return (CalculateAge(birthday) >= 18);
        }
    }
}
