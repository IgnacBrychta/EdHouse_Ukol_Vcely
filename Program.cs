using System.Text;
using System.IO;
using System.Buffers;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace EdHouse_Ukol_Vcely
{
    internal static class Program
    {
        const int maxInputSize = 10_000;
        static int width;
        static int height;
        static Forest? forest;
        static void Main(string[] args)
        {
#warning není výpis do stdout
            ShowWarning();
            int numOfTrees = GetForestDataSize();
            Clipboard.SetClipboardText("\r\n"); // 9997
            char[] rawData = GetForestData(numOfTrees);
            int[,] treeHeights = ParseRawData(rawData);
            GenerateForest(treeHeights);
            forest!.DetermineTreeVisibilityFromOutside();
            Console.Clear();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(forest[i, j] + "/");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Sečteno máme {forest.TreesOnEdges} stromů viditelných na okraji a dalších {forest.TreesVisibleInsideForest} uvnitř a celkem tedy {forest.TotalVisibleTrees} stromů viditelných");
            ShowVisibleTrees();
            var a = 0;
            Console.ReadKey();
        }

        static void ShowWarning()
        {
            Console.WriteLine("Pro správný chod tohoto programu je doporučeno mít zapnutou historii schránky. Lze pohodlně aktivovat pomocí WinKey+R, zadat \"ms-settings:clipboard\" a potvrdit. Stiskněte libovolné tlačítko pro pokračování.");
            Console.ReadKey();
        }

        static char[] GetForestData(int numOfTrees)
        {
            Console.WriteLine("Vložte seznam výšek stromů. Instrukce:\n 1. Zkopírovat seznam přesně jako v zadání\n 2. Vložit (WinKey+V)\n 3. Vložit speciální znak pro nový řádek (WinKey+V; ve schránce se objeví jako prázdné místo.");
            TextReader textIn = Console.In;
            char[] buffer = new char[numOfTrees];
            //textIn.ReadBlock(buffer, 0, maxInputSize);
            int _ = textIn.ReadBlock(buffer, 0, numOfTrees);
            return buffer;
        }

        static int GetForestDataSize()
        {
            int dataSize = 0;
            Console.WriteLine("Kolik znaků mají vstupní data?\nNápověda: celkový počet znaků = sloupce * řádky + 2 * řádky - 2\nPříklad: pro les o velikosti 5 × 5 je vkládáno 33 znaků");
            while(!int.TryParse(Console.ReadLine(), out dataSize) || dataSize > maxInputSize)
            {
                Console.WriteLine("Neplatný vstup.");
            }
            return dataSize;
        }

        static int[,] ParseRawData(in char[] rawData)
        {
            List<List<char>> data = new List<List<char>>() { new List<char>() };
            int row = 0;
            foreach (char item in rawData)
            {
                // ASCII: 0 -> 48, 9 -> 57
                if(item >= 48 && item <= 57)
                {
                    data[row].Add(item);
                }
                else if(item == '\n' || item == '\r')
                {
                    if (data.Count - 1 <= row)
                    {
                        data.Add(new List<char>());
                    }
                    else
                    {
                        row++;
                    }
                    
                }
            }
            int forestWidth = data[0].Count;
            int forestHeight = data.Count;
            int[,] treeHeights = new int[forestWidth, forestHeight];
            for (int i = 0; i < forestWidth; i++)
            {
                for (int j = 0; j < forestHeight; j++)
                {
                    treeHeights[i, j] = (int)char.GetNumericValue(data[i][j]);
                }
            }
            width = forestWidth;
            height = forestHeight;
            return treeHeights;
        }

        static void GenerateForest(in int[,] treeHeights)
        {
            forest = new Forest(width, height, treeHeights);
        }

        static void ShowVisibleTrees()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Tree tree = forest![i, j];
                    if(tree.isVisible)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write(tree.isVisible ? 'T' : 'F');
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = default;
        }
    }
}