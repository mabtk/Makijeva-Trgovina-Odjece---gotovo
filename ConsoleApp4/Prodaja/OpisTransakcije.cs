using ConsoleApp4.CijenaProizvoda;
using ConsoleApp4.Proizvod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Prodaja
{
    public class OpisTransakcije
    {
        private List<IGrouping<int, Transakcije>> cijelaTransakcija;

        public int IdTransakcije { get; set; }
        public string ImeKupca { get; set; }
        public DateTime DatumTransakcije { get; set; }
        public int IdProizvoda { get; set; }
        public string ImeProizvoda { get; set; }
        public Cijena CijenaProizvoda { get; set; }

        public OpisTransakcije() { }

        public OpisTransakcije(int idTransakcije, string imeKupca, DateTime datumTransakcije, int idProizvoda, string imeProizvoda, Cijena cijenaProizvoda)
        {
            IdTransakcije = idTransakcije;
            ImeKupca = imeKupca;
            DatumTransakcije = datumTransakcije;
            IdProizvoda = idProizvoda;
            ImeProizvoda = imeProizvoda;
            CijenaProizvoda = cijenaProizvoda;
        }

        public void DugiOpisTransakcija(OpisTransakcije transakcija)
        {
            Console.WriteLine($"ID transakcije - {transakcija.IdTransakcije}\nIme kupca - {transakcija.ImeKupca}\nDatum transakcije - {transakcija.DatumTransakcije}\nID proizvoda - {transakcija.IdProizvoda}\nIme proizvoda - {transakcija.ImeProizvoda}\nCijena proizvoda - {transakcija.CijenaProizvoda}");
        }

        public List<OpisTransakcije> UčitavanjeTransakcija()
        {
            UčitavanjeTransakcija učitavanjeTransakcija = new();
            UčitavanjeProizvoda učitavanjeProizvoda = new();
            List<Transakcije> spisakTransakcija = učitavanjeTransakcija.UčitajTransakcije();
            List<Proizvodi> spisakProizvoda = učitavanjeProizvoda.UčitajProizvode();

            Console.WriteLine("Transakcije: " + spisakTransakcija.Count);
            Console.WriteLine("Proizvodi: " + spisakProizvoda.Count);

            var cijelaTransakcija = (from transakcija in spisakTransakcija
                                     join proizvod in spisakProizvoda
                                     on transakcija.IdTransakcije equals proizvod.IdProizvoda
                                     select new OpisTransakcije
                                     {
                                         IdTransakcije = transakcija.IdTransakcije,
                                         ImeKupca = transakcija.ImeKupca,
                                         DatumTransakcije = transakcija.DatumTransakcije,
                                         IdProizvoda = transakcija.IdProizvoda,
                                         ImeProizvoda = proizvod.ImeProizvoda,
                                         CijenaProizvoda = proizvod.CijenaProizvoda
                                     }).OrderBy(p => p.IdTransakcije).ToList();
            return cijelaTransakcija;
        }
        public List<IGrouping<string, OpisTransakcije>> TestGrupiranjeMetoda()
        {
            List<OpisTransakcije> listaSvihTransakcija = new List<OpisTransakcije>();
            OpisTransakcije opis = new OpisTransakcije();
            listaSvihTransakcija = opis.UčitavanjeTransakcija();
            var cijelaLista = (from transakcija in listaSvihTransakcija
                               orderby transakcija.IdProizvoda
                               group transakcija by transakcija.ImeKupca into imena
                               select imena).ToList();
            foreach (var grupa in cijelaLista)
            {
                foreach (var transakcija in grupa)
                {
                    Console.WriteLine($"Ime kupca: {transakcija.ImeKupca}; Datum transakcije: {transakcija.DatumTransakcije}; ID proizvoda - {transakcija.IdProizvoda}");
                }
            }
            return cijelaLista;
        }

        public List<IGrouping<int, OpisTransakcije>> GrupiranjePoIDProizvoda()
        {
            List<OpisTransakcije> listaSvihTransakcija = new();
            OpisTransakcije opis = new OpisTransakcije();
            listaSvihTransakcija = opis.UčitavanjeTransakcija();
            var cijelaLista = (from transakcija in listaSvihTransakcija
                               orderby transakcija.ImeKupca
                               group transakcija by transakcija.IdProizvoda into trans
                               select trans).ToList();
            return cijelaLista;
        }

        public List<IGrouping<string, OpisTransakcije>> GrupiranjeSaWhere()
        {
            List<OpisTransakcije> listaSvihTransakcija = new();
            OpisTransakcije opis = new OpisTransakcije();
            listaSvihTransakcija = opis.UčitavanjeTransakcija();
            var cijelaLista = (from transakcija in listaSvihTransakcija
                               orderby transakcija.IdTransakcije
                               group transakcija by transakcija.ImeKupca into trans
                               where trans.Count() > 5
                               select trans).ToList();
            return cijelaLista;
        }
        public List<string> GrupiranjeKaoDistinct()
        {
            List<OpisTransakcije> listaSvihTransakcija = new();
            OpisTransakcije opis = new OpisTransakcije();
            listaSvihTransakcija = opis.UčitavanjeTransakcija();
            var cijelaLista = (from transakcija in listaSvihTransakcija
                               group transakcija by transakcija.ImeKupca into trans
                               select trans.Key).ToList();
            for (int i = 0; i < cijelaLista.Count; i++)
            {
                Console.WriteLine(cijelaLista[i]);
            }
            return cijelaLista;
        }
        public OpisTransakcije MinByMetoda()
        {
            List<OpisTransakcije> listaSvihTransakcija = new();
            OpisTransakcije opis = new OpisTransakcije();
            listaSvihTransakcija = opis.UčitavanjeTransakcija();
            var minByVrijednost = (from trans in listaSvihTransakcija select trans).MinBy(trans => trans.CijenaProizvoda.CijenaProizvoda);
            return minByVrijednost;
        }

        public double ProsjecnaCijenaProizvoda()
        {
            List<OpisTransakcije> listaSvihTransakcija = new();
            OpisTransakcije opis = new OpisTransakcije();
            listaSvihTransakcija = opis.UčitavanjeTransakcija();
            var prosjecnaCijena = (from trans in listaSvihTransakcija select trans.CijenaProizvoda.CijenaProizvoda).Average();
            return prosjecnaCijena;
        }
    }
}
