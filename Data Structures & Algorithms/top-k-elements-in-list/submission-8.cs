public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // 1. find the min and max in the nums
        int min = 0, max = 0;
        foreach(var num in nums){
            if(num < min) min = num;
            if (num > max) max = num;
        }

        // 2. Get frenquenct for values in the nums
        int[] countArr = new int[max - min + 1];
        foreach(int num in nums)
        {
            countArr[num - min]++;
        }

        // 3. bucket by frenquency
        List<int>[] countToElements = new List<int>[nums.Length + 1];
        for(int i = 0; i< countArr.Length; i++)
        {
            int freq = countArr[i];
            if(freq == 0) 
            {
                continue; // skip if array value is 0
            }
            
            if(countToElements[freq] == null)
            {
                countToElements[freq] = new List<int>();
            }

            int value = i+min;
            countToElements[freq].Add(value);
        }

        // 4. Return top array result
        int[] result = new int[k];
        int index = 0;

        for(int freq = countToElements.Length - 1; freq >= 0 && index < k; freq--){
            if (countToElements[freq] == null) continue;
            foreach(int value in countToElements[freq])
            {
                result[index++] = value;
                if(index == k)
                {
                    break;
                }
            }
        }
        return result;
    }
}
