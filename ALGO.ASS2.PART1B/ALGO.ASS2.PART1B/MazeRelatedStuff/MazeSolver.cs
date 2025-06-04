using ALGO.ASS2.PART1B.DataTypes;
namespace ALGO.ASS2.PART1B.MazeRelatedStuff;

    public static class MazeSolver
    {
        // I guess this should return a string announcing which wizard reaches the exit first, not sure if it works properly though :D
        public static string DetermineWinner(Wizard[] wizards, int[,] distanceMap)
        {
            double bestTime = double.PositiveInfinity;
            int winningWizardIndex = -1;

            for (int i = 0; i < wizards.Length; i++)
            {
                double? time = ComputeTimeToExit(wizards[i], distanceMap);
                if (time.HasValue && time.Value < bestTime)
                {
                    bestTime = time.Value;
                    winningWizardIndex = i;
                }
            }

            if (winningWizardIndex < 0)
                return "No wizard can reach the exit.";

            // Wizard indices are 0-based
            return $"Wizard #{winningWizardIndex + 1} wins (time: {bestTime:F2} min).";
        }
        
        private static double? ComputeTimeToExit(Wizard wizard, int[,] distanceMap)
        {

            int corridorCount = distanceMap[wizard.Position.Row, wizard.Position.Col];

            if (corridorCount < 0)
                return null;

            // each corridor takes 1 / speed minutes
            return corridorCount / wizard.Speed;
        }
    }