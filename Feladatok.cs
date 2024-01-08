//Feladatok.cs
namespace ToDo;

using System;

public class Feladatok
{
    public static void FeladatHozzaadasa()
    {
        //Meg kell adni a nevet és külön a dátumot, a dátum lehet macerás de így jól néz ki --Dominik
        try
        {
            Console.Clear();
            Console.WriteLine("Adja meg a feladat nevét:");
            string feladatNev = Console.ReadLine();

            Console.WriteLine("Adja meg a határidőt (pl.: 2024-01-07):");
            string hatranyDatum = Console.ReadLine();

            // Formázd a feladatot a fájlba való íráshoz
            string feladatAdatok = $"{feladatNev} - Határidő: {hatranyDatum}";

            // Fájlba írás
            string filePath = @"..\..\txtk\nemkeszfeladatok.txt";
            File.AppendAllText(filePath, feladatAdatok + Environment.NewLine);

            Console.WriteLine("A feladat sikeresen hozzáadva a fájlhoz.");
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt a feladat hozzáadása során: " + ex.Message);
            Thread.Sleep(2000);
        }
    }
    
    public static void KeszFeladat()
    {
        try
        {
            //Kiírja itt is hogy lehessen látni, hogy mit szeretnél kész-é tenni --Erik
            try
            {
                Console.Clear();
                string filePath = @"..\..\txtk\nemkeszfeladatok.txt";

                // Ellenőrizzük, hogy a fájl létezik-e
                if (File.Exists(filePath))
                {
                    // Olvassuk be a fájl tartalmát
                    string[] lines = File.ReadAllLines(filePath);

                    // Kiírjuk a tartalmat a konzolra
                    Console.WriteLine("Nem kész feladatok:");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("A fájl nem található: " + filePath);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt a fájl olvasása során: " + ex.Message);
            }
            
            // Kérjük meg a felhasználót a feladat nevének megadására
            Console.WriteLine("Adja meg a kész feladat nevét:");
            string keszFeladatNev = Console.ReadLine();

            // Ellenőrizzük, hogy a feladat szerepel-e a "nemkeszfeladatok.txt"-ben
            string nemKeszFilePath = @"..\..\txtk\nemkeszfeladatok.txt";
            string keszFilePath = @"..\..\txtk\keszfeladatok.txt";

            string[] nemKeszLines = File.ReadAllLines(nemKeszFilePath);
            bool talalat = false;

            // Ellenőrizzük, hogy a feladat szerepel-e a "nemkeszfeladatok.txt"-ben
            foreach (string line in nemKeszLines)
            {
                if (line.Contains(keszFeladatNev))
                {
                    talalat = true;

                    // Kinyerjük a határidőt a sorból
                    string hatarido = line.Split("- Határidő:")[1].Trim();

                    // Töröljük a feladatot a "nemkeszfeladatok.txt"-ből
                    List<string> modositottNemKeszLines = new List<string>(nemKeszLines);
                    modositottNemKeszLines.RemoveAll(l => l.Contains(keszFeladatNev));
                    File.WriteAllLines(nemKeszFilePath, modositottNemKeszLines);

                    // Adjuk hozzá a feladatot a "keszfeladatok.txt"-hez
                    File.AppendAllText(keszFilePath, $"{keszFeladatNev} - Határidő: {hatarido}" + Environment.NewLine);

                    Console.WriteLine("A feladat sikeresen készre jelölve.");
                    Thread.Sleep(2000);
                    break;
                }
            }

            if (!talalat)
            {
                Console.WriteLine("A megadott feladat nem található a nem kész feladatok között.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt a feladat készre jelölése során: " + ex.Message);
        }
    }

    
    public static void ModositFeladat()
    {
        try
        {
            Console.Clear();
            //Itt van egy kis duplázódás de az nem baj --Erik
            try
            {
                string filePath_kiiras = @"..\..\txtk\nemkeszfeladatok.txt";

                // Ellenőrizzük, hogy a fájl létezik-e
                if (File.Exists(filePath_kiiras))
                {
                    // Olvassuk be a fájl tartalmát
                    string[] lines_kiiras = File.ReadAllLines(filePath_kiiras);

                    // Kiírjuk a tartalmat a konzolra
                    Console.WriteLine("Nem kész feladatok:");
                    foreach (string line in lines_kiiras)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("A fájl nem található: " + filePath_kiiras);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt a fájl olvasása során: " + ex.Message);
            }
            
            Console.WriteLine("Adja meg a módosítandó feladat nevét:");
            string feladatNev = Console.ReadLine();

            // Ellenőrizzük, hogy a feladat szerepel-e a "nemkeszfeladatok.txt"-ben
           
            string tempFilePath = @"..\..\txtk\temp.txt";
            string filePath = @"..\..\txtk\nemkeszfeladatok.txt";
            string[] lines = File.ReadAllLines(filePath);
            List<string> modositottLines = new List<string>(lines);
            bool talalat = false;

            foreach (string line in lines)
            {
                if (line.Contains(feladatNev))
                {
                    talalat = true;

                    // Megjelenítjük a feladat adatait
                    Console.WriteLine("Eredeti feladat adatai: " + line);

                    // Kérjük meg a felhasználót a módosítások elvégzésére
                    Console.WriteLine("Adja meg az új nevet (ha nem szeretnéd módosítani, üss Enter-t):");
                    string ujNev = Console.ReadLine();

                    Console.WriteLine("Adja meg az új határidőt (ha nem szeretnéd módosítani, üss Enter-t):");
                    string ujHatarido = Console.ReadLine();

                    // Módosítjuk a feladatot
                    string modositottFeladat = (ujNev != "") ? $"{ujNev} - Határidő: {line.Split("- Határidő:")[1]}" : line;
                    modositottFeladat = (ujHatarido != "") ? $"{line.Split("- Határidő:")[0]} - Határidő: {ujHatarido}" : modositottFeladat;

                    // Módosított feladat hozzáadása a listához
                    modositottLines.Remove(line);
                    modositottLines.Add(modositottFeladat);

                    Console.WriteLine("A feladat sikeresen módosítva.");
                    Thread.Sleep(2000);
                    break;
                }
            }

            // Ha nem találtuk meg a feladatot, akkor kiírjuk az üzenetet
            if (!talalat)
            {
                Console.WriteLine("A megadott feladat nem található a nem kész feladatok között.");
                return;
            }

            // Módosított lista írása a fájlba
            File.WriteAllLines(tempFilePath, modositottLines);
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt a feladat módosítása során: " + ex.Message);
        }
    }
}