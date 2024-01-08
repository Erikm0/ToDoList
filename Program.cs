// Program.cs
using System;

namespace ToDo
{
    class Program
    {
        static void Main()
        {
            bool kilepes = false;
            //Amíg a felhasználó nem lép ki --Ákos
            while (!kilepes)
            {
                //Bekéri, hogy mit szeretnél csinálni, és átvisz oda
                Console.WriteLine("Mit szeretnél csinálni:\n -Feladatot hozzáadni\n -Nem kész feladatok megtekintése [todo]\n -Kész feladatok megtekintése [keszek-megnezese]\n -Feladat késszé tétele [kesz-lett]\n -Feladatot módosítani [modositani]\n -Kilépni [kilepni]");
                string muvelet = Console.ReadLine();

                switch (muvelet.ToLower())
                {
                    case "hozzaadni":
                        Feladatok.FeladatHozzaadasa();
                        break;

                    case "todo":
                        ToDoList.NemKeszFeladatokKiiratasa();
                        break;
                    
                    case "keszek-megnezese":
                        ToDoList.KeszFeladatokKiiratasa();
                        break;
                    
                    case "kesz-lett":
                        Feladatok.KeszFeladat();
                        break;

                    case "modositani":
                        Feladatok.ModositFeladat();
                        break;

                    case "kilepni":
                        kilepes = true;
                        Console.WriteLine("Viszontlátásra!");
                        break;

                    default:
                        Console.WriteLine("Érvénytelen művelet.");
                        break;
                }
            }
        }
    }
}