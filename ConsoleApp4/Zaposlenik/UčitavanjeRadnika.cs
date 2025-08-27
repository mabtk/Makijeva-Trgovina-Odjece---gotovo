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

namespace ConsoleApp4.Zaposlenik
{
    public class UčitavanjeRadnika
    {
        public List<Zaposlenik> UčitajRadnike()
        {

            var a = AppDomain.CurrentDomain.BaseDirectory;
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SpisakRadnika.txt");
            bool postoji = File.Exists(putanja);
            List<Zaposlenik> spisakRadnika = new List<Zaposlenik>();

            spisakRadnika.Clear();
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

                        string[] dijelovi = linija.Split(',');

                        if (dijelovi.Length != 5)
                        {
                            Console.WriteLine($"Neispravan format linije: {linija}");
                            continue;
                        }

                        string imeZaposlenika = dijelovi[0];
                        string prezimeZaposlenika = dijelovi[1];
                        int godineZaposlenika = int.Parse(dijelovi[2]);
                        string sifraZaposlenika = dijelovi[3];

                        if (!Enum.TryParse(dijelovi[4], out PolozajiRadnika polozajZaposlenika))
                        {
                            Console.WriteLine($"Neispravna vrijednost cijene u liniji: {linija}");
                            continue;
                        }

                        Zaposlenik zaposlenik;

                        switch (polozajZaposlenika)
                        {
                            case PolozajiRadnika.Radnik:
                                zaposlenik = new Radnik(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, sifraZaposlenika, polozajZaposlenika);
                                break;
                            case PolozajiRadnika.Menadžer:
                                zaposlenik = new Menadžer(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, sifraZaposlenika, polozajZaposlenika);
                                break;
                            default:
                                zaposlenik = new Gazda(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, sifraZaposlenika, polozajZaposlenika);
                                break;
                        }

                        spisakRadnika.Add(zaposlenik);
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
            return spisakRadnika;
        }

        public Zaposlenik LogIn()
        {
            bool login = false;
            while (true)
            {
                List<Zaposlenik> popisInformacija = new List<Zaposlenik>();
                popisInformacija = ProvjeraInformacija();

                Console.Write("Unesite vaše ime - ");
                string loginIme = Console.ReadLine();

                Console.Write("Unesite vašu šifru - ");
                string loginSifra = Console.ReadLine();

                var korisnickeInformacije = popisInformacija.FirstOrDefault(z => z.imeZaposlenika == loginIme && z.sifraZaposlenika == loginSifra);

                if (korisnickeInformacije != null)
                {
                    Console.WriteLine("Uspješno ste se logirali u aplikaciju.\nKliknite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    Console.Clear();
                    return korisnickeInformacije;
                }
                else
                {
                    Console.WriteLine("Niste unijeli valjano ime ili šifru.\nPokušajte ponovno.");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }

        public List<Zaposlenik> ProvjeraInformacija()
        {
            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            zaposlenici = UčitajRadnike();
            var listaInformacija = (from zaposlenik in zaposlenici
                                    select zaposlenik).ToList();
            return listaInformacija;
        }
    }
}
