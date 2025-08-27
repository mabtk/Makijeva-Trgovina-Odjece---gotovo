using ConsoleApp4.CijenaProizvoda;
using ConsoleApp4.Proizvod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Prodaja
{
    public class Transakcije
    {
        public string ImeKupca { get; set; }
        public DateTime DatumTransakcije { get; set; }
        public int IdTransakcije { get; set; }
        public int IdProizvoda { get; set; }

        public Transakcije(string imeKupca, DateTime datumTransakcije, int idTransakcije, int idProizvoda)
        {
            ImeKupca = imeKupca;
            DatumTransakcije = datumTransakcije;
            IdTransakcije = idTransakcije;
            IdProizvoda = idProizvoda;
        }

        public Transakcije()
        {
        }
    }
}
