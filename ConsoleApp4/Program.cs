
﻿using ConsoleApp4.CijenaProizvoda;
using ConsoleApp4.Prodaja;


using ConsoleApp4.CijenaProizvoda;

using ConsoleApp4.Proizvod;
using ConsoleApp4.Ugovor;
using ConsoleApp4.Zaposlenik;
using System.ComponentModel.DataAnnotations;
using static ConsoleApp4.Prodaja.Transakcije;

Console.WriteLine("Hello, World!");

UčitavanjeRadnika učitavanje = new UčitavanjeRadnika();
UčitavanjeProizvoda ucitavanjeProizvoda = new UčitavanjeProizvoda();
OpisTransakcije opisTransakcija = new();



Console.WriteLine("Hello, World!");


string putanja = $"C:\\Users\\Marko Rakic\\source\\zadaci\\ConsoleApp4\\SpisakProizvoda.txt";

Console.WriteLine(" .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.   \r\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |  \r\n| | ____    ____ | || |      __      | || |  ___  ____   | || |     _____    | || |     _____    | || |  _________   | || | ____   ____  | || |      __      | |  \r\n| ||_   \\  /   _|| || |     /  \\     | || | |_  ||_  _|  | || |    |_   _|   | || |    |_   _|   | || | |_   ___  |  | || ||_  _| |_  _| | || |     /  \\     | |  \r\n| |  |   \\/   |  | || |    / /\\ \\    | || |   | |_/ /    | || |      | |     | || |      | |     | || |   | |_  \\_|  | || |  \\ \\   / /   | || |    / /\\ \\    | |  \r\n| |  | |\\  /| |  | || |   / ____ \\   | || |   |  __'.    | || |      | |     | || |   _  | |     | || |   |  _|  _   | || |   \\ \\ / /    | || |   / ____ \\   | |  \r\n| | _| |_\\/_| |_ | || | _/ /    \\ \\_ | || |  _| |  \\ \\_  | || |     _| |_    | || |  | |_' |     | || |  _| |___/ |  | || |    \\ ' /     | || | _/ /    \\ \\_ | |  \r\n| ||_____||_____|| || ||____|  |____|| || | |____||____| | || |    |_____|   | || |  `.___.'     | || | |_________|  | || |     \\_/      | || ||____|  |____|| |  \r\n| |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |  \r\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |  \r\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'   \r\n .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .-----------------. .----------------.   \r\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |  \r\n| |  _________   | || |  _______     | || |    ______    | || |     ____     | || | ____   ____  | || |     _____    | || | ____  _____  | || |      __      | |  \r\n| | |  _   _  |  | || | |_   __ \\    | || |  .' ___  |   | || |   .'    `.   | || ||_  _| |_  _| | || |    |_   _|   | || ||_   \\|_   _| | || |     /  \\     | |  \r\n| | |_/ | | \\_|  | || |   | |__) |   | || | / .'   \\_|   | || |  /  .--.  \\  | || |  \\ \\   / /   | || |      | |     | || |  |   \\ | |   | || |    / /\\ \\    | |  \r\n| |     | |      | || |   |  __ /    | || | | |    ____  | || |  | |    | |  | || |   \\ \\ / /    | || |      | |     | || |  | |\\ \\| |   | || |   / ____ \\   | |  \r\n| |    _| |_     | || |  _| |  \\ \\_  | || | \\ `.___]  _| | || |  \\  `--'  /  | || |    \\ ' /     | || |     _| |_    | || | _| |_\\   |_  | || | _/ /    \\ \\_ | |  \r\n| |   |_____|    | || | |____| |___| | || |  `._____.'   | || |   `.____.'   | || |     \\_/      | || |    |_____|   | || ||_____|\\____| | || ||____|  |____|| |  \r\n| |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |  \r\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |  \r\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'   \r\n .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.                                           \r\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |                                          \r\n| |     ____     | || |  ________    | || |     _____    | || |  _________   | || |     ______   | || |  _________   | |                                          \r\n| |   .'    `.   | || | |_   ___ `.  | || |    |_   _|   | || | |_   ___  |  | || |   .' ___  |  | || | |_   ___  |  | |                                          \r\n| |  /  .--.  \\  | || |   | |   `. \\ | || |      | |     | || |   | |_  \\_|  | || |  / .'   \\_|  | || |   | |_  \\_|  | |                                          \r\n| |  | |    | |  | || |   | |    | | | || |   _  | |     | || |   |  _|  _   | || |  | |         | || |   |  _|  _   | |                                          \r\n| |  \\  `--'  /  | || |  _| |___.' / | || |  | |_' |     | || |  _| |___/ |  | || |  \\ `.___.'\\  | || |  _| |___/ |  | |                                          \r\n| |   `.____.'   | || | |________.'  | || |  `.___.'     | || | |_________|  | || |   `._____.'  | || | |_________|  | |                                          \r\n| |              | || |              | || |              | || |              | || |              | || |              | |                                          \r\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |                                          \r\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  ");


List<Proizvodi> proizvodi = new List<Proizvodi>();

var nastavak = Console.ReadKey(true);

Console.WriteLine("Kliknite tipku ENTER za ulazak u aplikaciju. ");
var a = Console.ReadKey(true);

if (a.Key == ConsoleKey.Enter)
{
    Console.Clear();
}

Console.WriteLine("Dobrodošli u Makijevu trgovinu odjeće");
Console.WriteLine("-------------------------------------");

Console.WriteLine("Molimo logirajte se u aplikaciju.");

var lista = učitavanje.UčitajRadnike();
Console.WriteLine($"Broj učitanih radnika - {lista.Count}");
Zaposlenik prijavljeniZaposlenik = učitavanje.LogIn();
List<Transakcije> spisakTransakcija = new();
List<OpisTransakcije> opisSvihTransakcija = new();

int opcija = 0;
bool boolVrijednost = false;
do
{
    Console.WriteLine("Molimo odaberite opciju:\n1. Provjera zaliha proizvoda\n2. Upravljanje zalihama proizvoda\n3. Ispis svih zaliha proizvoda\n4. Učitvanje proizvoda\n5. Informacije o zaposleniku\n6. Povijest transakcija\n9. Izlaz iz aplikacije");

    nastavak = a;

    do
    {
        try
        {
            opcija = int.Parse(Console.ReadLine());
            boolVrijednost = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Niste unijeli brojčanu vrijednost");
        }
    }
    while (!boolVrijednost);
   
    switch (opcija)
    {
        case 1:
            Console.Clear();
            foreach (var proizvod in proizvodi)
            {
                Console.WriteLine($"Proizvod: {proizvod.ImeProizvoda}, Količina: {proizvod.KolicinaProizvoda}");
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("Pritisnite bilo koju tipku za povratak u glavni meni");
            Console.ReadKey(true);
            Console.Clear();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Proizvodi u zalihama");
            foreach (var proizvod in proizvodi)
            {
                Console.WriteLine($"ID: {proizvod.IdProizvoda}, Ime: {proizvod.ImeProizvoda}, Količina: {proizvod.KolicinaProizvoda}");
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("Odaberite željenu akciju:\n1. Nadopuna proizvoda\n2. Prodaja proizvoda\n3. Dugi opis proizvoda\n4. Povratak na glavni meni");
            Console.WriteLine("-----------------------------------");
            boolVrijednost = false;
            int akcija = 0;
            do
            {
                try
                {
                    akcija = int.Parse(Console.ReadLine());
                    boolVrijednost = true;
                }

                catch (FormatException)
                {
                    Console.WriteLine("Niste unijeli brojčanu vrijednost");
                }
            }
            while (!boolVrijednost);

            switch (akcija)
            {
                case 1:
                    while (nastavak.Key != ConsoleKey.N)
                    {
                        Console.Clear();
                        Console.WriteLine("Odaberite ID proizvoda za nadopunu:");
                        foreach (var proizvod in proizvodi)
                        {
                            Console.WriteLine($"ID: {proizvod.IdProizvoda}, Ime: {proizvod.ImeProizvoda}, Količina: {proizvod.KolicinaProizvoda}");
                        }
                        Console.WriteLine("Odaberite ID proizvoda za nadopunu.");
                        int odabirProizvoda = 0;
                        boolVrijednost = false;
                        do
                        {
                            try
                            {
                                odabirProizvoda = int.Parse(Console.ReadLine());
                                boolVrijednost = true;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Unesite brojčanu vrijednost.");
                            }
                        }
                        while (!boolVrijednost);


                        proizvodi[odabirProizvoda - 1].NadopunaProizvoda();
                        Console.WriteLine("Želite li nadopuniti još neki proizvod? (Y/N)");
                        nastavak = Console.ReadKey(true);
                        Console.Clear();
                    }
                    break;
                case 2:
                    while (nastavak.Key != ConsoleKey.N)
                    {
                        Console.Clear();
                        Console.WriteLine("Odaberite ID proizvoda za prodaju:");
                        foreach (var proizvod in proizvodi)
                        {
                            Console.WriteLine($"ID: {proizvod.IdProizvoda}, Ime: {proizvod.ImeProizvoda}, Količina: {proizvod.KolicinaProizvoda}");
                        }
                        int odabirProizvoda = int.Parse(Console.ReadLine());
                        proizvodi[odabirProizvoda - 1].ProdajaProizvoda();
                        Console.WriteLine("Želite li prodati još neki proizvod? (Y/N)");
                        nastavak = Console.ReadKey(true);
                        Console.Clear();
                    }
                    break;
                case 3:
                    Console.Clear();

                    proizvodi = Proizvodi.Filtriranje();
                    Proizvodi metodeProizvoda = new();
                    metodeProizvoda.DugiOpisProizvoda();

                    proizvodi = Proizvodi.Filtriranje();
                    foreach (var proizvod in proizvodi)
                    {
                        proizvod.DugiOpisProizvoda();
                        proizvod.TestProizvoda();
                        Console.WriteLine("-----------------------------------");
                    }

                    Console.WriteLine("Pritisnite bilo koju tipku za povratak na glavni meni.");
                    var nastavak3 = Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    break;
            }
            break;
        case 3:
            Console.Clear();
            foreach (var proizvod in proizvodi)
            {
                Console.WriteLine($"Ime proizvoda - {proizvod.ImeProizvoda}\nKoličina proizvoda - {proizvod.KolicinaProizvoda}");
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("Pritisnite bilo koju tipku za povratak u glavni meni");
            var nastavak4 = Console.ReadKey(true);
            Console.Clear();
            break;
        case 4:
            Console.Clear();

            proizvodi = ucitavanjeProizvoda.UčitajProizvode();
            proizvodi = Proizvodi.SortiranjeProizvoda();

            UčitavanjeProizvoda ucitavanje = new UčitavanjeProizvoda();
            proizvodi = ucitavanje.UčitajProizvode();
            proizvodi = Proizvodi.SortiranjeProizvoda();

            Console.WriteLine($"Učitano {proizvodi.Count} proizvoda");
            Console.WriteLine("Kliknite bilo koju tipku za nastavak.");
            Console.ReadKey(true);
            Console.Clear();
            break;
        case 5:
            Console.Clear();
            prijavljeniZaposlenik.InformacijeOZaposleniku();
            Console.WriteLine("Kliknite bilo koju tipku za nastavak.");
            Console.ReadKey(true);
            Console.Clear();
            break;

        case 6:
            Console.Clear();
            Console.WriteLine("Odaberite željenu akciju");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Učitaj transakcije\n2. Pregled svih transakcija");
            int opcijaTransakcija = int.Parse(Console.ReadLine());

            switch (opcijaTransakcija)
            {
                case 1:
                    Console.Clear();
                    opisSvihTransakcija = opisTransakcija.UčitavanjeTransakcija();
                    Console.WriteLine($"Učitani broj transakcija - {opisSvihTransakcija.Count}");
                    Console.WriteLine("Pritisnite bilo koju tipku za nastavak");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    foreach (OpisTransakcije transakcija in opisSvihTransakcija)
                    {
                        opisTransakcija.DugiOpisTransakcija(transakcija);
                        Console.WriteLine("-----------------------------------");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            Console.Clear();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Vaš odabir nije među opcijama");
            Console.WriteLine("Pokušajte ponovno.");
            Console.ReadLine();
            Console.Clear();
            break;
    }
}
while (opcija != 9);