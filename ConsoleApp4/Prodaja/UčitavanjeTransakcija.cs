using ConsoleApp4.Zaposlenik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Prodaja
{
    public class UčitavanjeTransakcija
    {
        public List<Transakcije> UčitajTransakcije()
        {
            List<Transakcije> spisakTransakcija = new();

            var a = AppDomain.CurrentDomain.BaseDirectory;
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SpisakTransakcija.txt");
            bool postoji = File.Exists(putanja);

            if (postoji == true)
            {
                string[] linije = File.ReadAllLines(putanja);
                foreach (string linija in linije)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(linija))
                        {
                            continue;
                        }

                        string[] dijelovi = linija.Split(',');

                        if (dijelovi.Length != 4)
                        {
                            Console.WriteLine($"Neispravan format linije: {linija}");
                            continue;
                        }

                        string imeKupca = dijelovi[0];
                        DateTime datumTransakcije = DateTime.Parse(dijelovi[1]);
                        int idTransakcije = int.Parse(dijelovi[2]);
                        int idProizvoda = int.Parse(dijelovi[3]);

                        Transakcije transakcija = new(imeKupca, datumTransakcije, idTransakcije, idProizvoda);

                        spisakTransakcija.Add(transakcija);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Greška pri čitanju linije: {linija}. Detalji: {ex.Message}");
                    }
                }
            }
            else
            {
                using FileStream fs = File.Create(putanja);
                Console.WriteLine("Kreirana je nova datoteka jer prethodna nije postojala.");
            }
            return spisakTransakcija;
        }
    }
}
