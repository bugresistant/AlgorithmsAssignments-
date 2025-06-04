namespace AlgorithmsAssignmentsPart2Task2;

// Represents the guest-dislike graph
public class Graph
{ 
    public int Size { get; }
    public string[] Names { get; }

    // Adjacency list representing dislike relationships
    // Adjacency[i] contains all nodes that guest with index [i] hates
    public List<int>[] Adjacency { get; }

    public Graph(int size)
    {
        Size = size;
        Names = new string[size];
        Adjacency = new List<int>[size];
        for (int i = 0; i < size; i++)
            Adjacency[i] = new List<int>();
    }
}