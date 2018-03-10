using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadanie1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Wybierz testy:");

            Console.WriteLine("1. Tabelka 2x2 z prostymi liczbami");
            Console.WriteLine("2. Tabelka 2x3 z długimi tekstami");
            Console.WriteLine("3. Odczyt danych pliku, zapis tabeli wynikowej do pliku .html, " +
                              "wraz z nagłówkiem html (tak, żeby się dało obejrzeć w przeglądarce)");
            Console.WriteLine("4. Tabela 2x5 z wierszem nagłówkowym");

            var choose = int.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    var rows1 = SimpleNumbers(2, 2);
                    var generator1 = new Generator(rows1);
                    Console.WriteLine(generator1.GeneratedHtml);
                    break;
                case 2:
                    var rows2 = LongStrings(2, 3);
                    var generator2 = new Generator(rows2);
                    Console.WriteLine(generator2.GeneratedHtml);
                    break;
                case 3:
                    var text = File.ReadAllText("input.csv");
                    var rowsList = text.Split('\n').ToList();
                    var table = new List<List<Tuple<string, string>>>();
                    var i = 0;
                    rowsList.ForEach(delegate(string s)
                    {
                        if (s.Length != 0)
                        {
                            var cells = s.Split(",").ToList();
                            table.Add(new List<Tuple<string, string>>());
                            foreach (var cell in cells) table[i].Add(new Tuple<string, string>("cell", cell));
                        }

                        i++;
                    });

                    var generator3 = new Generator(table);
                    File.WriteAllText("input.html", generator3.GeneratedHtml);
                    break;
                case 4:
                    var rows4 = LongStrings(2, 5);
                    var generator4 = new Generator(rows4, rows4);
                    Console.WriteLine(generator4.GeneratedHtml);
                    break;
            }
        }

        private static List<List<Tuple<string, string>>> SimpleNumbers(int m, int n)
        {
            var rows = new List<List<Tuple<string, string>>>();

            for (var i = 0; i < m; i++)
            {
                rows.Add(new List<Tuple<string, string>>());
                for (var j = 0; j < n; j++)
                {
                    var random = new Random();
                    rows[i].Add(new Tuple<string, string>("cell", random.Next(100).ToString()));
                }
            }

            return rows;
        }

        private static List<List<Tuple<string, string>>> LongStrings(int m, int n)
        {
            var rows = new List<List<Tuple<string, string>>>();

            for (var i = 0; i < m; i++)
            {
                rows.Add(new List<Tuple<string, string>>());
                for (var j = 0; j < n; j++)
                {
                    var guid = Guid.NewGuid();
                    rows[i].Add(new Tuple<string, string>("cell", guid.ToString()));
                }
            }

            return rows;
        }
    }
}