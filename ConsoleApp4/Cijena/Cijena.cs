
using ConsoleApp4.Proizvod;
using ConsoleApp4.CijenaProizvoda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.CijenaProizvoda
{
    public class Cijena
    {
        private double cijenaProizvoda { get; set; }
        private Valuta valutaProizvoda { get; set; }
        public double CijenaProizvoda
        {
            get { return cijenaProizvoda; }
            private set { cijenaProizvoda = value; }
        }
        public Valuta ValutaProizvoda
        {
            get { return valutaProizvoda; }
            private set { valutaProizvoda = value; }
        }
        public Cijena(double cijenaProizvoda, Valuta valutaProizvoda)
        {
            this.CijenaProizvoda = cijenaProizvoda;
            this.ValutaProizvoda = valutaProizvoda;
        }

        public override string ToString()
        {
            return $"{CijenaProizvoda} {ValutaProizvoda}";
        }
        
    }
}
