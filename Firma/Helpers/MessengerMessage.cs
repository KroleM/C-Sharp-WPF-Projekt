using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Helpers
{
    public class MessengerMessage<TypNadawcy, TypZwracany>
    {
        public TypNadawcy Nadawca { get; set; }
        public TypZwracany ZwracanyObiekt { get; set; }
        public string Wiadomosc { get; set; }
    }
}
