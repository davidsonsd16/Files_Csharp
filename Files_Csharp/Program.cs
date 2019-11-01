using System;
using System.IO;
using System.Globalization;

namespace Files_Csharp {
    class Program {
        static void Main(string[] args) {

            string pathIn = @"C:\Users\david\Downloads\Curso - POO Csharp\Code\Files_Csharp\data.csv";
            string pathOut = @"C:\Users\david\Downloads\Curso - POO Csharp\Code\Files_Csharp\out\summary.csv";
            //Directory.CreateDirectory(@"C:\Users\david\Downloads\Curso - POO Csharp\Code\Files_Csharp\out");
            try {
                string[] lines = File.ReadAllLines(pathIn);

                using (StreamWriter sw = File.AppendText(pathOut)) {
                    foreach (string line in lines) {
                        string[] columns = line.Split(",");
                        double Total = double.Parse(columns[1], CultureInfo.InvariantCulture) * int.Parse(columns[2], CultureInfo.InvariantCulture);
                        sw.WriteLine(columns[0] + "," + Total.ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch(IOException e) {
                Console.WriteLine("Unexpectep error: " + e.Message);
            }
        }
    }
}
