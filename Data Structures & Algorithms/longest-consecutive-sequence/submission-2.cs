public class Solution {
    public int LongestConsecutive(int[] nums) {
       var numSet = new HashSet<int>(nums);

        int maxLength = 0;
        foreach(var n in numSet)
        {
            if(numSet.Contains(n - 1)) continue;

            int currentLength = 1;
            int next = n + 1;

            // Loop inside the numSet to find the matched value
            while(numSet.Contains(next))
            {
                next++;
                currentLength++;
            }
            
            maxLength =  Math.Max(maxLength, currentLength);
                              
        }

        return maxLength;
    }
}
