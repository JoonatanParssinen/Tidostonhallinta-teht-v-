namespace tehtava;

class Program
{
    static void Main(string[] args)
    {
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
                valitut.Add(vastaus);
            }
        }
    }
}
