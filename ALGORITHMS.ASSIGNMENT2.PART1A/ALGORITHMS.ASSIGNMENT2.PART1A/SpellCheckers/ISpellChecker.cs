namespace ALGORITHMS.ASSIGNMENT2.PART1A;

public interface ISpellChecker
{
    public string ApproachTypeName { get; }
    IEnumerable<string> CheckSpelling(IEnumerable<string> inputFile);
}