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
    }
}
