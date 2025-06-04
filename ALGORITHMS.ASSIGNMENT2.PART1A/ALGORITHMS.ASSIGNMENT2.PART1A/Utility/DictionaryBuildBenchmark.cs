using BenchmarkDotNet.Attributes;
using ALGORITHMS.ASSIGNMENT2.PART1A;

[MemoryDiagnoser]
public class DictionaryBuildBenchmark
{
    private readonly string dictPath =
        TextProcessor.GetSourceRelativePath(@"..\TextFiles\english_words.txt");

    // Each constructor invocation builds its own structure
    [Benchmark]
    public object BuildLinear() => new NaiveApproach(TextProcessor.BuildWordsDictionary(dictPath));

    [Benchmark]
    public object BuildBst() => new BstApproach(TextProcessor.BuildWordsDictionary(dictPath));

    [Benchmark]
    public object BuildHashSet() => new HashSetApproach(TextProcessor.BuildWordsDictionary(dictPath));

    [Benchmark]
    public object BuildTrie() => new TrieApproach(TextProcessor.BuildWordsDictionary(dictPath));
}