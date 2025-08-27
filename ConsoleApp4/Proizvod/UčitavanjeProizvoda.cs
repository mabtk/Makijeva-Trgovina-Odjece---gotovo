using ConsoleApp4.CijenaProizvoda;
using ConsoleApp4.Proizvod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4.Proizvod
{
    public class UčitavanjeProizvoda
    {
        List<Proizvodi> spisakProizvoda = new List<Proizvodi>();
        public List<Proizvodi> UčitajProizvode()
        {
            var a = AppDomain.CurrentDomain.BaseDirectory;
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SpisakProizvoda.txt");
            bool postoji = File.Exists(putanja);
            spisakProizvoda.Clear();
            if (postoji)
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

                        string[] dijelovi = linija.Split(';');

                        if (dijelovi.Length != 7)
                        {
                            Console.WriteLine($"Neispravan format linije: {linija}");
                            continue;
                        }

                        int idProizvoda = int.Parse(dijelovi[0]);
                        string imeProizvoda = dijelovi[1];
                        string opisProizvoda = dijelovi[2];

                        if (!double.TryParse(dijelovi[3], out double iznos))
                        {
                            Console.WriteLine($"Neispravna vrijednost cijene u liniji: {linija}");
                            continue;
                        }

                        if (!Enum.TryParse<Valuta>(dijelovi[4], true, out Valuta valuta))
                        {
                            Console.WriteLine($"Neispravna valuta u liniji: {linija}");
                            continue;
                        }

                        if (!Enum.TryParse<TipProizvoda>(dijelovi[5], true, out TipProizvoda tipProizvoda))
                        {
                            Console.WriteLine($"Neispravan tip proizvoda u liniji: {linija}");
                            continue;
                        }

                        if (!int.TryParse(dijelovi[6], out int kolicina))
                        {
                            Console.WriteLine($"Neispravna količina u liniji: {linija}");
                            continue;
                        }

                        Cijena cijenaProizvoda = new Cijena(iznos, valuta);

                        double ukupnaCijena = 0;

                        Proizvodi proizvod;
                        
                        switch (tipProizvoda)
                        {
                            case TipProizvoda.Tene:
                                proizvod = new Tene(idProizvoda, imeProizvoda, opisProizvoda, cijenaProizvoda, tipProizvoda, kolicina, ukupnaCijena);
                                break;
                            case TipProizvoda.Majica:
                                proizvod = new Majica(idProizvoda, imeProizvoda, opisProizvoda, cijenaProizvoda, tipProizvoda, kolicina, ukupnaCijena);
                                break;
                            default:
                                proizvod = new Hlače(idProizvoda, imeProizvoda, opisProizvoda, cijenaProizvoda, tipProizvoda, kolicina, ukupnaCijena);
                                break;
                        }

                        spisakProizvoda.Add(proizvod);
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
            return spisakProizvoda;
        }
    }
}
