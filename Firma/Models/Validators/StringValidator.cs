using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class StringValidator : Validator
    {
        public static string CannotBeTooLong(string value) => value?.Length > 64 ? "Tekst nie może być dłuższy niż 64 znaki" : string.Empty;
        public static string CannotBeEmpty(string value) => value == string.Empty ? "To pole nie może być puste!" : string.Empty;
    }
}
