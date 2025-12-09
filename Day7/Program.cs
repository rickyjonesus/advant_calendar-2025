// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string filePath = "./data.txt";

var lines = File.ReadAllLines(filePath);
var linesList = lines.Select(l => l.ToArray()).ToArray();
int totalSplits = 0;

int lastRowDecisinoPoint = linesList.Length - 1;
for (int i = 0; i < linesList.Count() - 1; i++)
{
    var line = linesList[i];
    var nextLine = linesList[i + 1];

    for (int ci = 0; ci < line.Length; ci++)
    {
        var c = line[ci];
        if (line[ci] == 'S' || line[ci] == '|')
        {
     
            if (nextLine[ci] == '^')
            {
                totalSplits++;
                nextLine[ci - 1] = '|';
                nextLine[ci + 1] = '|';
            }
            else  nextLine[ci] = '|';

        }
    }
}
foreach (var l in linesList)
{
    Console.WriteLine(new string(l));
}

Console.WriteLine($"Total splits: {totalSplits}");

class particleSplitter
{
    static void SplitParticles(char[][] linesList)
    {
        
    }
}