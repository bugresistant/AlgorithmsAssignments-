using AlgorithmsAssignmentsPart2Task2;

using var reader = new StreamReader(args[0]);
var graph = GraphReader.ReadFrom(new StreamReader(args[0]));
if (!BicoloringSolver.TryColor(graph, out var color))
{
    Console.WriteLine("Impossible");
    return;
}

var firstTable = new List<string>();
var secondTable = new List<string>();

for (int i = 0; i < graph.Size; i++)
{
    if (color[i] == 0) firstTable.Add(graph.Names[i]);
    else secondTable.Add(graph.Names[i]);
}

Console.WriteLine("Table 1:");
firstTable.ForEach(Console.WriteLine);

Console.WriteLine("Table 2:");
secondTable.ForEach(Console.WriteLine);