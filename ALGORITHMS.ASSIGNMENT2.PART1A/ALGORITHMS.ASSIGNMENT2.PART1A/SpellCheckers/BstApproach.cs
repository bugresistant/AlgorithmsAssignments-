namespace ALGORITHMS.ASSIGNMENT2.PART1A;

public class BstApproach : ISpellChecker
{
    private readonly SortedSet<string> _dictionaryWords;
    public string ApproachTypeName => "Balanced BST (SortedSet)";

    public BstApproach(IEnumerable<string> dictionaryWords)
    {
        _dictionaryWords = new SortedSet<string>(dictionaryWords);
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