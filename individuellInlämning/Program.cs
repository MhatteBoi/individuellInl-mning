using System;
using System.Collections.Generic;
using System.IO;

namespace individuellInlämning
{
        class Program
        {
            static void Main()
            {
                // Testa metoden med en string array
                string[] inputArray = { "apple", "banana", "avocado", "orange", "grape" };
                List<string> filteredList = FilterStringsStartingWithA(inputArray);

                // Skapa katalog och spara listan som fil
                CreateAndSaveListToFile("A", filteredList);  // Gör så att bokstav tas in som input av användare FÖR ATT FILTRERA ORD?

                Console.WriteLine("Operationen slutförd.");
            }

            // Metod för att filtrera element som börjar på "a" och returnera en generisk lista
            static List<string> FilterStringsStartingWithA(string[] inputArray)
            {
                List<string> result = new List<string>();

                foreach (string str in inputArray)
                {
                    if (str.StartsWith("a", StringComparison.OrdinalIgnoreCase)) // ser till att inte gnälla över stor eller liten bokstav
                    {
                        result.Add(str);
                    }
                }

                return result;
            }

            // Metod för att skapa en katalog och spara en lista som en fil
            static void CreateAndSaveListToFile(string startingLetter, List<string> listToSave)
            {
                // Skapa katalogen om den inte redan finns
                string directoryPath = Path.Combine(Environment.CurrentDirectory, startingLetter);
                if (!Directory.Exists(directoryPath)) // Denna del kollar om den finns
                {
                    Directory.CreateDirectory(directoryPath); // Om den finns så skapar den the path
                }

                // Sätt filens sökväg
                string filePath = Path.Combine(directoryPath, $"{startingLetter}_List.txt");

                // Skriv listan till filen
                File.WriteAllLines(filePath, listToSave);
            }
        }
    }
