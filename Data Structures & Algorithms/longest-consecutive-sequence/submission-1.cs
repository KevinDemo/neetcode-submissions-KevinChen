public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> mapper = new HashSet<int>();
        // Store the char of the string;
        for(int i = 0; i < nums.Length; i++){
            if(!mapper.Add(nums[i])) continue;
            mapper.Add(nums[i]);
        }

        int maxLength = 0;
        for(int i = 0; i < nums.Length; i++){
            if(!mapper.Contains(nums[i] - 1)){
                int currentLength = 1;
                int nextNumber = nums[i] + 1;
                // Loop inside the mapper to find the matched value
                while(mapper.Contains(nextNumber))
                {
                    nextNumber++;
                    currentLength++;
                }

                // for(int j = 0; j < mapper.Count; j++){
                //     if(mapper.Contains(nextNumber)){
                //         nextNumber++;
                //         currentLength++;
                //     }
                // } 
              maxLength =  Math.Max(maxLength, currentLength);
            }                   
        }

        return maxLength;
    }
}
