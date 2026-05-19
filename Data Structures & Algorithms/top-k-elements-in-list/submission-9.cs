public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var count = new Dictionary<int,int>();
        foreach(var num in nums)
        {
            count[num] = count.GetValueOrDefault(num,0) + 1;
        }

        var heap = new PriorityQueue<int, int>();
        foreach (var kvp in count)
        {
            heap.Enqueue(kvp.Key, kvp.Value);
            if (heap.Count > k) heap.Dequeue();
        }

        var result = new int[k];
        for(int i = 0; i<k; i++) result[i] = heap.Dequeue();
        return result;
    }
}
