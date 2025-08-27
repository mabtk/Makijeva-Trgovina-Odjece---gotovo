using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Zaposlenik
{
    public class Zaposlenik
    {
        public string imeZaposlenika;
        public string prezimeZaposlenika;
        public int godineZaposlenika;
        public string sifraZaposlenika;
        public PolozajiRadnika polozajRadnika;

        public Zaposlenik() { }

        public Zaposlenik(string imeZaposlenika, string prezimeZaposlenika, int godineZaposlenika, string sifraZaposlenika, PolozajiRadnika polozajRadnika)
        {
            this.imeZaposlenika = imeZaposlenika;
            this.polozajRadnika = polozajRadnika;
            this.godineZaposlenika = godineZaposlenika;
            this.sifraZaposlenika = sifraZaposlenika;
            this.polozajRadnika = polozajRadnika;
        }
        public void InformacijeOZaposleniku()
        {
            Console.WriteLine($"Ime zaposlenika - {imeZaposlenika}\n" +
                $"Prezime zaposlenika - {prezimeZaposlenika}\n" +
                $"Godine zaposlenika - {godineZaposlenika}\n" +
                $"Položaj zaposlenika - {polozajRadnika}");
        }

    }
}
