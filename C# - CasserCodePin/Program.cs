using System;
using System.Threading;

namespace CasserCodePin
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Début du programme");
            // **********************************
            Console.WriteLine("Choisissez le mode de jeu :");
            Console.WriteLine("1. Choix aléatoire ");
            Console.WriteLine("2. Choix manuel");

            int choixMode = 0;
            bool saisieValide = false;

            // Sélectio mode de jeu
            while (!saisieValide)
            {
                Console.Write("\nVotre choix : ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out choixMode) && choixMode >= 1 && choixMode <= 2)
                {
                    saisieValide = true;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer 1 ou 2.");
                }
            }

            // Définition du code secret
            int codeSecret = 0;
            Random rnd = new Random();

            if (choixMode == 1)
            {
                // Code secret aléatoire
                codeSecret = rnd.Next(10000);
            }
            else
            {
                // Choix manuel
                bool pinValide = false;
                while (!pinValide)
                {
                    Console.Write("\nEntrez un code secret (entre 0000 et 9999) : ");
                    string? inputPin = Console.ReadLine();

                    if (int.TryParse(inputPin, out codeSecret) && codeSecret >= 0 && codeSecret <= 9999)
                    {
                        pinValide = true;
                    }
                    else
                    {
                        Console.WriteLine("Code invalide. Il doit être entre 0 et 9999.");
                    }
                }
            }

            Console.WriteLine("\nLancement du brute-force...\n");

            // Chronomètre
            DateTime start = DateTime.Now;

            // Brute-force
            bool trouve = false;
            int codePinTrouve = 0;
            int i = 0;

            while (i < 10000 && !trouve)
            {
                Console.Write(i + " ");

                // Tempo
                Thread.Sleep(1000);

                if (i == codeSecret)
                {
                    trouve = true;
                    codePinTrouve = i;
                    break;
                }
                i++;
            }

            // Résultats
            Console.WriteLine($"\n\nLe code PIN trouvé est : {codePinTrouve:D4}");
            Console.WriteLine("Fin du programme");

            TimeSpan duree = DateTime.Now - start;
            Console.WriteLine($"Durée de la recherche : {duree.TotalSeconds:F2} secondes");

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}