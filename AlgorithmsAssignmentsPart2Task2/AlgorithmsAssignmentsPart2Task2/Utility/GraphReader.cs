namespace AlgorithmsAssignmentsPart2Task2;

static class GraphReader
{
    public static Graph ReadFrom(TextReader reader)
    {
        int n = int.Parse(reader.ReadLine());
        var graph = new Graph(n);

        for (int i = 0; i < n; i++)
            graph.Names[i] = reader.ReadLine().Trim();

        // Create a name-to-index mapping for look easily for guests
        var index = new Dictionary<string, int>(n);
        for (int i = 0; i < n; i++)
            index[graph.Names[i]] = i;
        
        int dislikePairCount = int.Parse(reader.ReadLine());

        // Adding undirected edges between the guests for each dislike pair
        for (int i = 0; i < dislikePairCount; i++)
        {
            // Split line into two
            var parts = reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Convert names to indices with dictionary 
            int u = index[parts[0]];
            int v = index[parts[1]];

            // Add each as a neighbor to the other (bidirectional dislike or whatever that's called I'm not sure)
            graph.Adjacency[u].Add(v);
            graph.Adjacency[v].Add(u);
        }

        return graph;
    }
}