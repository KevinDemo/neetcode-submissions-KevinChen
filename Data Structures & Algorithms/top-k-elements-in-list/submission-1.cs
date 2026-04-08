public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
      // Step 1: Count frequencies
    Dictionary<int, int> freq = new Dictionary<int, int>();
    foreach (int num in nums)
    {
        if (!freq.ContainsKey(num))
            freq[num] = 0;
        freq[num]++;
    }

    // Step 2: Create buckets (array of lists)
    List<int>[] buckets = new List<int>[nums.Length + 1];
    for (int i = 0; i < buckets.Length; i++)
    {
        buckets[i] = new List<int>();
    }

    // Step 3: Fill buckets
    foreach (var kvp in freq)
    {
        int number = kvp.Key;
        int frequency = kvp.Value;
        buckets[frequency].Add(number);
    }

    // Step 4: Collect k elements from highest frequency bucket backwards
    List<int> result = new List<int>();
    for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--)
    {
        foreach (int num in buckets[i])
        {
            result.Add(num);
            if (result.Count == k) break;
        }
    }

    return result.ToArray();
    }
}
