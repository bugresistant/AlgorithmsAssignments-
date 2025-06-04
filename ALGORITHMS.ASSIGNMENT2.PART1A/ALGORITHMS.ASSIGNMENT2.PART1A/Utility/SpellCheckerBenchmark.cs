using BenchmarkDotNet.Attributes;

namespace ALGORITHMS.ASSIGNMENT2.PART1A;

[MemoryDiagnoser]
public class SpellCheckerBenchmark
{
    // SETUP
    // 3 inputs: small (~10 KB), medium (~100 KB), large (Alice ~150 KB)
    [Params("small.txt", "medium.txt", "AliceInWonderland.txt")]
    public string TextFileName { get; set; }

    private string textPath;

    private readonly string englishWordsFilePath = TextProcessor.GetSourceRelativePath(@"..\TextFiles\english_words.txt");
    
    private List<string> inputWords;

    private ISpellChecker linear;
    private ISpellChecker bst;
    private ISpellChecker hash;
    private ISpellChecker trie;
    
    [GlobalSetup]
    public void Setup()
    {
        textPath = TextProcessor.GetSourceRelativePath($@"..\TextFiles\{TextFileName}");
        var dictionaryWords = TextProcessor.BuildWordsDictionary(englishWordsFilePath);
        inputWords = TextProcessor.LoadAndSplitText(textPath);

        linear = new NaiveApproach(dictionaryWords);
        bst    = new BstApproach(dictionaryWords);
        hash   = new HashSetApproach(dictionaryWords);
        trie   = new TrieApproach(dictionaryWords);
    }
    
    [Benchmark]
    public List<string> LinearCheck() => linear.CheckSpelling(inputWords).ToList();

    [Benchmark]
    public List<string> BstCheck() => bst.CheckSpelling(inputWords).ToList();

    [Benchmark]
    public List<string> HashSetCheck() => hash.CheckSpelling(inputWords).ToList();

    [Benchmark]
    public List<string> TrieCheck() => trie.CheckSpelling(inputWords).ToList();
}