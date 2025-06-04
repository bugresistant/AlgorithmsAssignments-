using ALGO.ASS2.PART1B.DataTypes;
namespace ALGO.ASS2.PART1B.MazeRelatedStuff;

public static class DistanceMap
{
    public static int[,] BuildDistanceMap(char[,] mazeGrid, Point exitPoint)
    {
        int rowCount = mazeGrid.GetLength(0);
        int columnCount = mazeGrid.GetLength(1);

        // Initialize all distances to -1 (unvisited)
        int[,] distanceMap = new int[rowCount, columnCount];
        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        {
            for (int colIndex = 0; colIndex < columnCount; colIndex++)
            {
                distanceMap[rowIndex, colIndex] = -1;
            }
        }

        // BSF start from ext point
        var cellsToVisit = new Queue<Point>();
        cellsToVisit.Enqueue(exitPoint);
        distanceMap[exitPoint.Row, exitPoint.Col] = 0;

        // Offsets for the directions
        int[] rowOffsets = { -1, +1, 0, 0 };
        int[] colOffsets = { 0, 0, -1, +1 };

        while (cellsToVisit.Count > 0)
        {
            Point current = cellsToVisit.Dequeue();
            int currentDistance = distanceMap[current.Row, current.Col];
            
            for (int i = 0; i < rowOffsets.Length; i++)
            {
                int neighborRow = current.Row + rowOffsets[i];
                int neighborCol = current.Col + colOffsets[i];

                // Check bounds
                bool inside = (neighborRow >= 0 && neighborRow < rowCount) && (neighborCol >= 0 && neighborCol < columnCount);
                if (!inside)
                    continue;

                // Check for wall and track visited cells
                if (mazeGrid[neighborRow, neighborCol] == '#'
                    || distanceMap[neighborRow, neighborCol] != -1)
                {
                    continue;
                }

                // Set distance and enqueue for further expansion
                distanceMap[neighborRow, neighborCol] = currentDistance + 1;
                cellsToVisit.Enqueue(new Point(neighborRow, neighborCol));
            }
        }

        return distanceMap;
    }
}