using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class DecimalValidator : Validator
    {
        /// <summary>
        /// W przypadku błędu, zwracamy jego komunikat. W przypadku braku błędu zwracamy null.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CzyWiekszeOdZera(decimal value) => value < 0 ? "Ta wartość nie może być mniejsza od zera" : null;

        public static string CzyProcent(decimal value) => value <= 100 && value >= 0 ? null : "Ta wartość musi reprezentować procent z przedziału 0-100%";
    }
}
