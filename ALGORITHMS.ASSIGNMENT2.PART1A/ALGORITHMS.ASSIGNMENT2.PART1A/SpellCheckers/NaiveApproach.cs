namespace ALGORITHMS.ASSIGNMENT2.PART1A;

public class NaiveApproach : ISpellChecker
{
    
    private readonly List<string> _dictionaryWords;
    public string ApproachTypeName => "Linear list";
    public NaiveApproach(IEnumerable<string> dictionaryWords)
    {
        _dictionaryWords = new List<string>(dictionaryWords).ToList();
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