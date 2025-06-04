namespace ALGORITHMS.ASSIGNMENT2.PART1A;

public class HashSetApproach : ISpellChecker
{
    private readonly ProperHashSet _dictionaryWords;
    public string ApproachTypeName => "HashSet";

    public HashSetApproach(IEnumerable<string> dictionaryWords)
    {
        // HashSet gives you average O(1) lookup
        _dictionaryWords = new ProperHashSet();
    }

    public IEnumerable<string> CheckSpelling(IEnumerable<string> inputFile)
    {
        var misspelledWords = new List<string>();

        foreach (var word in inputFile)
        {
            if (!_dictionaryWords.Contains(word)) 
            {
                misspelledWords.Add(word);
            }
        }

        return misspelledWords;
    }
}