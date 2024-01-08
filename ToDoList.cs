//ToDoList.cs
namespace ToDo;

using System;
using System.Collections.Generic;

public class ToDoList
{
    public static void NemKeszFeladatokKiiratasa()//Nem kész feladatok kiírása--Dominik
    {
        try
        {
            Console.Clear();
            string filePath = @"..\..\txtk\nemkeszfeladatok.txt";

            // Ellenőrizzük, hogy a fájl létezik-e
            if (File.Exists(filePath))
            {
                // Olvassuk be a fájl tartalmát
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    // Kiírjuk a tartalmat a konzolra
                    Console.WriteLine("Nem kész feladatok:");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Nincsen feladatod");
                }
            }
            else
            {
                Console.WriteLine("A fájl nem található: " + filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt a fájl olvasása során: " + ex.Message);
        }
    }
    public static void KeszFeladatokKiiratasa()//Itt a kész feladatokat írja ki --Ákos
    {
        try
        {
            Console.Clear();
            string filePath = @"..\..\txtk\keszfeladatok.txt";

            // Ellenőrizzük, hogy a fájl létezik-e
            if (File.Exists(filePath))
            {
                // Olvassuk be a fájl tartalmát
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    // Kiírjuk a tartalmat a konzolra
                    Console.WriteLine("Kész feladatok:");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Nincs kész még feladatod");
                }
            }
            else
            {
                Console.WriteLine("A fájl nem található: " + filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt a fájl olvasása során: " + ex.Message);
        }
    }
}