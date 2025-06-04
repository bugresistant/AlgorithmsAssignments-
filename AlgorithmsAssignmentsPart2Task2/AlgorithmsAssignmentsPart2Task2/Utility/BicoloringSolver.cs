namespace AlgorithmsAssignmentsPart2Task2;

// Solver for two-table seating via non-recursive DFS
class BicoloringSolver
{
    // Colors: -1 = unassigned, 0 or 1 represent some table
    public static bool TryColor(Graph graph, out int[] color)
    {
        int guestCount = graph.Size;
        color = new int[guestCount];
        
        // Initialize all the nodes with no color
        for (int i = 0; i < guestCount; i++) color[i] = -1;
        
        var guestStack = new Stack<int>();
        
        // Start from every unvisited guest
        for (int guest = 0; guest < guestCount; guest++)
        {
            if (color[guest] != -1)
                continue;

            // Start DFS and assign initial color 0
            color[guest] = 0;
            guestStack.Push(guest);

            while (guestStack.Count > 0)
            {
                int currentGuest = guestStack.Pop();
                
                foreach (int dislikedGuest in graph.Adjacency[currentGuest])
                {
                    if (color[dislikedGuest] == -1)
                    {
                        // Assign to opposite table of the current guest
                        color[dislikedGuest] = 1 - color[currentGuest];
                        guestStack.Push(dislikedGuest);
                    }
                    else if (color[dislikedGuest] == color[currentGuest])
                    {
                        //if conflict occurs
                        return false;
                    }
                }
            }
        }
        
        // Good output, TBH it would be better if the method returned tuple,
        // instead of accepting ref parameter (color array), anyway it works.
        return true;
    }
}