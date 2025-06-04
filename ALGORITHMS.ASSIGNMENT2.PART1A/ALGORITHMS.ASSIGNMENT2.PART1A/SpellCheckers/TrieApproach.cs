namespace ALGORITHMS.ASSIGNMENT2.PART1A
{
    // Simple spell checker using a trie
    public class TrieApproach : ISpellChecker
    {
        private readonly TrieNode _root;

        public string ApproachTypeName => "Trie";

        // Build the tree from all words in the dictionary
        public TrieApproach(IEnumerable<string> dictionaryWords)
        {
            _root = new TrieNode();
            foreach (var word in dictionaryWords)
            {
                if (!string.IsNullOrEmpty(word))
                    Insert(word);
            }
        }

        // Check each input word; collect those not found in the tree
        public IEnumerable<string> CheckSpelling(IEnumerable<string> inputFile)
        {
            var misspelled = new List<string>();
            foreach (var word in inputFile)
            {
                if (!Search(word))
                    misspelled.Add(word);
            }
            return misspelled;
        }

        // Add one word to the tree
        private void Insert(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                // If there's no branch for this letter, just create one
                if (!node.Children.TryGetValue(ch, out var next))
                {
                    next = new TrieNode();
                    node.Children[ch] = next;
                }
                node = next;
            }
            // Mark the last letter as the end of a valid word
            node.IsWordEnd = true;
        }

        // Look up one word in the tree
        private bool Search(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                // If we can't follow a letter, word is not in the dictionary
                if (!node.Children.TryGetValue(ch, out var next))
                    return false;
                node = next;
            }
            // It's only a match if the last letter was marked as a word end
            return node.IsWordEnd;
        }

        // Node in the letter tree: holds next letters and a flag for word endings
        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
            public bool IsWordEnd { get; set; }
        }
    }
}