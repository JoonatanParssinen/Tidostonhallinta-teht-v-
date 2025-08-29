namespace tehtava;
using System.Text.Json;

class Program
{

        static void Save(double prosentti)
    {
        string dirName = DateTime.Now.ToString("dd-MM-yyyy");
        string baseDir = AppContext.BaseDirectory;
        string fullDirPath = Path.Combine(baseDir, dirName);

        if (!Directory.Exists(fullDirPath))
        {
            Directory.CreateDirectory(fullDirPath);
        }
        string resultFile = Path.Combine(fullDirPath, "tulokset.json");
        var resultObj = new { Prosentti = prosentti };
        string json = JsonSerializer.Serialize(resultObj);
        if (File.Exists(resultFile) == false)
        {
            File.WriteAllText(resultFile, $"[\n{json}\n]");

        }
        else
        {
            var lines = File.ReadAllLines(resultFile).ToList();
            lines.RemoveAt(lines.Count - 1);
            lines[lines.Count - 1] += ",";
            lines.Add($"{json}\n]");
            File.WriteAllLines(resultFile, lines);
        }
    }
    
    
    static void Main(string[] args)
    {

        while (true)
        {

            Console.WriteLine("----------------------------");
            Console.WriteLine("Haluatko pelata (p)");
            Console.WriteLine("Vai tarkastella tuloksia (t)");
            Console.WriteLine("Haluatko lopettaa ohjelman (e)");
            Console.WriteLine("----------------------------\n");

            string rep = Console.ReadLine();

            if (rep.ToLower() == "p")
            {

                int oikeatmaara = 0;
                string tiedosto = Path.Combine(AppContext.BaseDirectory, "alkuaineet.txt");

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
                        if (k.ToLower() == vastaus.ToLower())
                        {
                            Console.WriteLine("Sama vastaus kuin aikaisemmin ei pysty hyväkysmään");
                            i -= 1;
                            listContainsSame = true;
                            continue;
                        }

                    }
                    if (listContainsSame == false)
                    {
                        if (eka20.Contains(vastaus.ToLower()))
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

                double prosentti = (oikeatmaara / 5.0) * 100;

                Console.WriteLine($"\nSait oikein {oikeatmaara}/5 ({prosentti:F1}%)"); // toi F1 estää liiallisia numeroita kuten 66.6666
                Console.WriteLine("\n------------Tulokset------------");

                Save(prosentti);

                continue;

            }
            else if (rep.ToLower() == "t")
            {

                string[] dirs = Directory.GetDirectories(AppContext.BaseDirectory);

                if (dirs.Length > 0)
                {
                    int tuloksetYhteensa = 0;
                    Console.WriteLine("\n--- [ Viime tulokset ] ---\n");

                    foreach (string dir in dirs)
                    {

                        string[] dirSplit = dir.Split(Path.DirectorySeparatorChar);
                        Console.WriteLine(dirSplit[dirSplit.Length - 1]);

                        string tiedosto = Path.Combine(AppContext.BaseDirectory, dir, "tulokset.json");

                        if (!File.Exists(tiedosto))
                        {
                            Console.WriteLine("Tiedostoa ei löytynyt: " + tiedosto);
                            return;
                        }

                        List<string> tulokset = File.ReadAllLines(tiedosto).ToList();

                        foreach (string rivi in tulokset)
                        {
                            if (!rivi.Contains(':'))
                            {
                                continue;
                            }

                            string[] tulos = rivi.Split(",");
                            string[] pala = tulos[0].Split(":");
                            int prosentti = Convert.ToInt32(pala[1].Trim().TrimEnd('}', ']'));
                            tuloksetYhteensa += prosentti;
                        }
                        Console.WriteLine("Keskiarvo: " + tuloksetYhteensa / (tulokset.Count - 2));
                        Console.Write("\n");

                    }

                    Console.WriteLine("--------------------------\n");

                }
                else
                {
                    Console.WriteLine("Tuloksia ei löydy!");
                }

            }
            else if (rep.ToLower() == "e")
            {
                Console.WriteLine("---------[ Kiitos pelaamisesta ]---------");
                break;
            }

            

        }

    }
}








