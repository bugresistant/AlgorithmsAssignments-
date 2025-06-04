using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ALGORITHMS.ASSIGNMENT2.PART1A;

public static class TextProcessor
{
    public static List<string> LoadAndSplitText(string filePath)
    {
        string rawText = File.ReadAllText(filePath);
        
        rawText = rawText.ToLowerInvariant();

        // Some regex magic to extract only alphabetic words (I hope it works not sure though)
        MatchCollection matches = Regex.Matches(rawText, @"\b[a-z]+\b");
        
        return matches.Select(m => m.Value).ToList();
    }

    public static List<string> BuildWordsDictionary(string filePath)
    {
        var words = File.ReadAllLines(filePath).Select(w => w.Trim().ToLower()).ToList();
        return words;
    }
    public static string GetSourceRelativePath(string relativePath, [CallerFilePath] string callerFilePath = "")
    {
        var basePath = Path.GetDirectoryName(callerFilePath)!;
        return Path.GetFullPath(Path.Combine(basePath, relativePath));
    }
}