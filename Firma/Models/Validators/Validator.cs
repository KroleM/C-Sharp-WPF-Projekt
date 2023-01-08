using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class Validator
    {
        public static string CannotBeNull(object value) => value == null ? "To pole nie może być puste" : string.Empty;
    }
}
