using ALGO.ASS2.PART1B.DataTypes;

namespace ALGO.ASS2.PART1B.MazeRelatedStuff;

public static class MazeParser
{
        public static (char[,] Grid, Point Exit, Wizard[] Wizards) ParseFromFile(string path)
        {
            var lines = File.ReadAllLines(path);

            int mazeRows = lines.Length - 3; // last 3 lines used to describe wizards and not the part of the maze therefore
            // probably I should have accepted wizards info and maze in separate files but anyways I'm just stick to this solution
            int mazeCols = lines[0].Length; // every maze line has the same number of characters, so we just look at first line to find width
            var grid = new char[mazeRows, mazeCols];

            Point exit = default;

            // Parse maze & locate exit
            for (int r = 0; r < mazeRows; r++)
            {
                if (lines[r].Length != mazeCols)
                    throw new InvalidDataException($"Line {r} length {lines[r].Length} != expected {mazeCols}.");

                for (int c = 0; c < mazeCols; c++)
                {
                    char ch = lines[r][c];
                    if (ch == '>')
                    {
                        exit = new Point(r, c);
                        grid[r, c] = '.';
                    }
                    else
                    {
                        grid[r, c] = ch; // '#' or '.'
                    }
                }
            }

            var wizards = new Wizard[3];
            for (int i = 0; i < wizards.Length; i++)
            {
                var parts = lines[mazeRows + i].Split();
                int row = int.Parse(parts[0]);
                int col = int.Parse(parts[1]);
                double speed = double.Parse(parts[2]);
                wizards[i] = new Wizard(new Point(row, col), speed);
            }

            return (grid, exit, wizards);
        }
}
    