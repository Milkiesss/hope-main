using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class RegexPatterns
    {
        public static readonly Regex Email = new(@"^[a-zA-Z0-9]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        public static readonly Regex PhoneNumber = new(@"^\d{10,}$");

        public static readonly Regex OnlyLetters = new("\\p{L}'?$");

        //"ГГГГ-ММ-ДД"
        public static readonly Regex date = new Regex(@"^\d{4}-\d{2}-\d{2}$");

    }
}
