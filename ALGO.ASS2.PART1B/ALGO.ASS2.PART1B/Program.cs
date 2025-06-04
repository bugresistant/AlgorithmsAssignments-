using ALGO.ASS2.PART1B.DataTypes;
using ALGO.ASS2.PART1B.MazeRelatedStuff;


var filePath = args[0];

// Parse everything and assign to local variables
(char[,] grid, Point exitPoint, Wizard[] wizards)
    = MazeParser.ParseFromFile(filePath);

int[,] distanceMap = DistanceMap.BuildDistanceMap(grid, exitPoint);

// Computing per‐wizard distances and arrival times
int wizardCount = wizards.Length;
int[] distances = new int[wizardCount];
double[] arrivalTimes = new double[wizardCount];

for (int i = 0; i < wizardCount; i++)
{
    var w = wizards[i];
    int d = distanceMap[w.Position.Row, w.Position.Col];
    distances[i] = d;
    arrivalTimes[i] = d < 0 ? double.PositiveInfinity : d / w.Speed;
}

// Winner finder
int winnerIndex = -1;
double bestTime = double.PositiveInfinity;
for (int i = 0; i < wizardCount; i++)
{
    if (arrivalTimes[i] < bestTime)
    {
        bestTime = arrivalTimes[i];
        winnerIndex = i;
    }
}

Console.WriteLine("=== Race Results ===");
for (int i = 0; i < wizardCount; i++)
{
    Console.WriteLine(
        $"Wizard #{i + 1}: distance={distances[i]}  speed={wizards[i].Speed}  arrival={arrivalTimes[i]:F2} minutes"
    );
}

Console.WriteLine(
    $"Winner: Wizard #{winnerIndex + 1} (arrival: {bestTime:F2} minutes)"
);