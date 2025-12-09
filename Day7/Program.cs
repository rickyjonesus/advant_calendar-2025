// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;

Console.WriteLine("Hello, World!");

string filePath = "./example-data.txt";

var lines = File.ReadAllLines(filePath);
var linesList = lines.Select(l => l.ToArray()).ToArray();

linesList = PathBuilder.BuildPath(linesList);

foreach (var l in linesList)
{
    Console.WriteLine(new string(l));
}


class PathBuilder
{
    public static char[][] BuildPath(char[][] lines)
    {
        int totalSplits = 0;
        int totalTimelines = 0;
        for (int rowIndex = 0; rowIndex < lines.Count() - 1; rowIndex++)
        {
            var line = lines[rowIndex];
            var nextLine = lines[rowIndex + 1];

            for (int columnIndex = 0; columnIndex < line.Length; columnIndex++)
            {
                var c = line[columnIndex];
                if (line[columnIndex] == 'S' || line[columnIndex] == '|')
                {

                    if (nextLine[columnIndex] == '^')
                    {
                        if (nextLine[columnIndex - 1] != '|')
                        {
                            nextLine[columnIndex - 1] = '|';
                            totalTimelines++;
                        }
                        if (nextLine[columnIndex + 1] != '|')
                        {
                            nextLine[columnIndex + 1] = '|';
                            totalTimelines++;
                        }
                        totalSplits++;

                    }
                    else nextLine[columnIndex] = '|';

                }
            }
            Console.WriteLine($"{new String(line)}: totalTimelines={totalTimelines}, totalTimelines={totalTimelines} ");

        }
        Console.WriteLine($"Total splits: {totalSplits}");
        Console.WriteLine($"Total timelines: {totalTimelines - 1}");
        return lines;
    }
}