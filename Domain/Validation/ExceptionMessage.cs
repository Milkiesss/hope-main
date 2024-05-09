using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class ExceptionMessage
    {
        public const string NullException = "{0} is null";

        public const string EmptyException = "{0} is empty";

        public const string PhoneNumberException = "{0} must contains only numbers";

        public const string EmailException = "{0} is invalid email address";

        public const string OnlyLetters = "{0} must contains only letters";

        public const string GreaterThanZero = "{0} must be greater than zero";

        public const string dateFormat = "{0} invalid Date";

        public const string charactersCount = "{0} too many characters";
    }
}
