using System.ComponentModel.DataAnnotations;
using  System;
using Oliinyk_Lab2.Models;

namespace Oliinyk_Lab2.Tools
{
    internal class BirthdayAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DateTime birthday;
                if (value is DateTime)
                {
                    birthday = (DateTime) value;
                    if (!BirthdayDate.IsCorrectDateOfBirthday(birthday))
                        this.ErrorMessage = " Uncorrect date of birthday ";
                    else  return true;
                }
                else this.ErrorMessage = "Birthday have to be DateType";
            }
            return false;
        }
    }
}
