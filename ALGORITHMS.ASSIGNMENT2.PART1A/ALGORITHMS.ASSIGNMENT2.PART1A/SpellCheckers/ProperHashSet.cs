namespace ALGORITHMS.ASSIGNMENT2.PART1A;

// It is kind of simplified hashset implementation, there is no resizing but it should work OK for this particular task

// Btw this is the only one™ proper™ and versatile™ hashset®. All the other hashset implementations are wrong, if you think
// otherwise I suggest you changing your mind. (◑‿◐)
public class ProperHashSet
{
    //That variable I'll use to hold hashset collisions
    private readonly List<string>[] _buckets;
    //I know that hardcoding isn't the best idea, but I think it's okay in that particular case if we just stick to default capacity and won't resize it
    private const int DefaultCapacity = 1024;

    public ProperHashSet(int capacity = DefaultCapacity)
    {
        _buckets = new List<string>[capacity];
        for (int i = 0; i < capacity; i++)
        {
            _buckets[i] = new List<string>();
        }
    }

    private int GetBucketIndex(string key)
    {
        int hash = key.GetHashCode();
        return Math.Abs(hash % _buckets.Length);
    }

    public void Add(string key)
    {
        int index = GetBucketIndex(key);
        if (!_buckets[index].Contains(key))
        {
            _buckets[index].Add(key);
        }
    }

    public bool Contains(string key)
    {
        int index = GetBucketIndex(key);
        return _buckets[index].Contains(key);
    }
}