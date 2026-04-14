public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // step 1: find min and max
        int min = nums[0], max = nums[0];
        foreach (int num in nums)
        {
            if (num < min) min = num;
            else if (num > max) max = num;
        }

        // step 2: frequency array for values in [min, max]
        int[] countArr = new int[max - min + 1];
        foreach (int num in nums)
        {
            countArr[num - min]++;
        }

        // step 3: bucket by frequency
        List<int>[] countToElements = new List<int>[nums.Length + 1];

        for (int i = 0; i < countArr.Length; i++)
        {
            int freq = countArr[i];
            if (freq == 0) continue; // todo move this to line 1 

            if (countToElements[freq] == null)
                countToElements[freq] = new List<int>();  

            int value = i + min;
            countToElements[freq].Add(value);
        }

        // step 4: collect top k frequent elements
        int[] result = new int[k];
        int index = 0;

        for (int freq = countToElements.Length - 1; freq >= 0 && index < k; freq--)
        {
            if (countToElements[freq] == null) continue;

            foreach (int value in countToElements[freq])
            {
                result[index++] = value;
                if (index == k)
                    break;
            }
        }

        return result;
    }
}
