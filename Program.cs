namespace tehtava;

class Program
{
    static void Main(string[] args)
    {
        int oikeatmaara = 0;
        string tiedosto = "alkuaineet.txt";
        if (!File.Exists(tiedosto))
        {
            Console.WriteLine("Tiedostoa ei löytynyt: " + tiedosto);
            return;
        }

        List<string> eka20 = File.ReadAllLines(tiedosto).ToList();

        List<string> valitut = new List<string>();

        Console.WriteLine("Anna viisi alkuainetta (vain 20 ensimmäisestä):");
        bool listContainsSame = false;
        for (int i = 0; i < 5; i++)
        {
            listContainsSame = false;
            string vastaus = Console.ReadLine();
            foreach (string k in valitut)
            {
                if (k == vastaus)
                {
                    Console.WriteLine("Sama vastaus kuin aikaisemmin ei pysty hyväkysmään");
                    i -= 1;
                    listContainsSame = true;
                    continue;
                }

            }
            if (listContainsSame == false)
            {
                if (eka20.Contains(vastaus))
                {
                    valitut.Add(vastaus);
                    oikeatmaara++;
                    // oikein, jippii, hurraa!!
                }
                else
                {
                    valitut.Add(vastaus);
                    // väääääääääääääääärin
                }
            }
        }
        Console.WriteLine("\n------------Tulokset------------\n");
        foreach (string vastaus in valitut)
        {
            if (eka20.Contains(vastaus))
                Console.WriteLine("[OIKEIN]  " + vastaus);
            else
                Console.WriteLine("[VÄÄRIN]  " + vastaus);
        }

        double prosentti = (oikeatmaara /5.0) * 100;
        Console.WriteLine($"\nSait oikein {oikeatmaara}/5 ({prosentti:F1}%)"); // toi F1 estää liiallisia numeroita kuten 66.6666
        Console.WriteLine("\n------------Tulokset------------");
    }
}
