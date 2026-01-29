using System;

class Unik_z_mistnosti
{
    static void Main()
    {
        //Definuje hlavní proměnné hry
        bool hraBezi = true; // určuje, zda hra pokračuje
        bool maKlic = false; // sleduje,zda hráč našel klíč


        Uvod(); // zavoláme proceduru - uvodní program

        // Hlavní herní smyčka
        while (hraBezi) {
            ZobrazMenu(); // Voláme procedůru která vypíše možnosti
            int volba = VolbaHrace(); // načte volbu hráče
            // vyhodnocujeme volbu
            switch (volba) {
                case 1:
                    ProhledniMistnost(); // hráč prohlíží místnost
                    break;

                case 2:
                    hraBezi = OtevriDvere(maKlic); // pokus o otevření dveří
                    break;

                case 3:
                    maKlic = ProhledejSkrin(maKlic); //hráč hledá klíč ve skříni
                    break;

                case 4:
                    maKlic = ProhledejKontejner(maKlic);
                    break;

                case 5:
                    maKlic = ProhledejKnihovnu(maKlic);
                    break;

            

                case 0:
                    if (maKlic)
                    {
                        Console.WriteLine("Konec hry.Jsi volný, unikl si kruté smrti!!!");
                        hraBezi = false;
                    }
                    else
                    {
                        Console.WriteLine("Nemůžeš odejít bez klíče!");
                    }
                    break;
                    
                    

                default:
                    Console.WriteLine("Neplatná volba, zkus to znova nebo se nikdy nedostaneš ven!!");
                    break;
            }
            Console.WriteLine(); // oddelilo jednotlive tahy, aby byl výpis přehledný

        }
        //Podpogramy/metody

        // uvodnii sprava pro hrace - procedura
        static void Uvod()
        {
            Console.WriteLine("Vítej v pekelné únikové hře!");
            Console.WriteLine("Jediná možnost jak uniknout z místnosti tvého posledního odpočinku, je najít zakletý klíč");
            Console.WriteLine("Používej jen tyto volby v menu k interakci s místností \n ");
        }

        //zobrazí menu
        static void ZobrazMenu()
        {
            Console.WriteLine("Co chceš udělat?");
            Console.WriteLine("1 - Prohlédnout místnost");
            Console.WriteLine("2 - Zkusit otevřít dveře");
            Console.WriteLine("3 - Prohledat skříň");
            Console.WriteLine("4 - Prohledat kontejner pod stolem");
            Console.WriteLine("5 - Prohledat knihovnu");
            Console.WriteLine("0 - Konec hry ");
        }

        // Nactení volby hráče
        static int VolbaHrace()
        {
            Console.WriteLine("Zadej svou volbu pomocí čísla");
            string vstup = Console.ReadLine();
            //Kontrola vstupu, jestli háč zadal číslo
            if (int.TryParse(vstup, out int volba))
                return volba;
            else
                return -1; // pokud je vstup neplatný vrátíme -1
        }

        //Prohlízení místnosti - procedůra,textový popis
        static void ProhledniMistnost()
        {
            Console.WriteLine("Místnost je upně bílá což je nezvyklé, ale je tam i nejaky nábytek pokryty jemným saténem ");
            Console.WriteLine("Doufej že tu ten klíč k útěku od smrti někde je");
        }

        //Hledání klíče ve skříni
        static bool ProhledejSkrin(bool maKlic)
        {
            if (maKlic)
            {
                Console.WriteLine("Našel jsi klíč ted rychle zdrhej");
                return true; // hráč má klíč
            }
            else
            {
                Console.WriteLine("Skříň je prázdna.");
                return maKlic; // klíč zustavá
            }
        }
        static bool ProhledejKontejner(bool maKlic)
        {
            if (!maKlic)
            {
                Console.WriteLine("Otevíráš šuplíky kontejneru...");
                Console.WriteLine("Našel jsi klíč schovaný mezi papíry!");
                return true;
            }
            else
            {
                Console.WriteLine("Kontejner je prázdný.");
                return maKlic;
            }
        }

        static bool ProhledejKnihovnu(bool maKlic)
        {
            if (!maKlic)
            {
                Console.WriteLine("Prohlížíš knihy jednu po druhé...");
                Console.WriteLine("Za starou knihou něco cinklo, ale klíč to není.");
                return false;
            }
            else
            {
                Console.WriteLine("V knihovně už nic zajímavého není.");
                return maKlic;
            }
        }

        static bool OtevriDvere( bool maKlic)
        {
            if (maKlic) 
            { 
            Console.WriteLine("Klíč použit jsi volný vítej zpátky ve smrtelném životě");
                return false; // hra skončila
            }

            else
            {
                Console.WriteLine("Nene neunikneš dokud klíč nebude tvůj");
                return true; //hra pokračuje
            }

        }
    }
}