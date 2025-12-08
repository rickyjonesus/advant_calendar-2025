// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Windows.Markup;


Console.WriteLine("Day 6");


string filePath = "./data.txt";

var lines = File.ReadAllLines(filePath);
var linesList = lines.ToList();

var columnDefs = GetColumnDefinitions(linesList);

//remove operator from list
linesList.RemoveAt(linesList.Count - 1);

Console.WriteLine($"Columns defined: {columnDefs.Count}");

int runningTotal = 0;
foreach (var column in columnDefs)
{
    var values = new long[column.ColumnWidth];
    for (int i = 0; i < column.ColumnWidth; i++)
    {

        int multiplier = 1;
        foreach (var line in linesList)
        {
            if (char.IsWhiteSpace(line[runningTotal]))
            {
                continue;
            }
            var digit = int.Parse(line[runningTotal].ToString());
            Console.WriteLine($"adding {values[i]} at position {runningTotal} with multiplier {multiplier} to  {digit}");

            values[i] = digit + (multiplier * values[i]);


            if (multiplier == 1) 
            {
                multiplier *= 10;
            }


        }
        runningTotal++;
        Console.WriteLine($" Column total: {values[i]}");
    }
    Console.WriteLine();
    runningTotal++;

    if(column.Operator == '+')
        column.bucket = values.Sum();
    else if (column.Operator == '*')
        column.bucket = values.Aggregate((a, b) => a * b);
    else
        Console.WriteLine($"Unknown operator {column.Operator} ");

}
var total = columnDefs.Sum(s => s.bucket);

Console.WriteLine($"Total: {total}");


static List<Column> GetColumnDefinitions(IEnumerable<string> lines)
{
    var columns = new List<Column>();
    int rowIndex = 0;
    foreach (var line in lines)
    {
        var columnDefs = line.Split(' ').Where(w => string.IsNullOrEmpty(w) == false).Select(cd => cd.Trim());
        int index = 0;
        foreach (var colDef in columnDefs)
        {
            if (rowIndex == 0)
            {
                var column = new Column();
                column.ColumnWidth = colDef.Length;
                columns.Add(column);

            }
            else
            {
                if (rowIndex == lines.Count() - 1)
                {
                    columns[index].Operator = colDef[0];
                }
                else if (colDef.Length > columns[index].ColumnWidth)
                {
                    columns[index].ColumnWidth = colDef.Length;
                }
            }
            index++;
        }
        rowIndex++;
    }
    return columns;
}

class Column
{
    public char Operator { get; set; }
    public int ColumnWidth { get; set; }

    public long bucket { get; set; }
}
