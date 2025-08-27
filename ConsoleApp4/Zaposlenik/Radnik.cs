using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Zaposlenik
{
    public class Radnik : Zaposlenik
    {
        public Radnik(string imeZaposlenika, string prezimeZaposlenika, int godineZaposlenika, string sifraZaposlenika, PolozajiRadnika polozajRadnika) : 
            base(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, sifraZaposlenika, polozajRadnika)
        {
        }
    }
}

