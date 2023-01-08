using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class StringValidator : Validator
    {
        public static string CannotBeTooLong(string value) => value?.Length > 64 ? "Nazwa nie może być dłuższa niż 64 znaki" : string.Empty;
    }
}
