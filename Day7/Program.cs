// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string filePath = "./example-data.txt";

var lines = File.ReadAllLines(filePath);
var linesList = lines.ToList();
for (int i = 0; i < linesList.Count - 1; i++)
{
    var line = linesList[i].ToArray();
    var nextLine = linesList[i + 1].ToArray();

    for (int ci = 0; ci < line.Length; ci++)
    {
        var c = line[ci];
        if(line[ci] == 'S' || line[ci] == '|')
        {
            nextLine[ci] = '|';
        }
        else if (line[ci] == '^' )
        {
            nextLine[ci-1] = '|';
            nextLine[ci+1] = '|';
            nextLine[ci] = '.';
        }
    }

    Console.WriteLine(new string(line));

}