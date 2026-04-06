public class Solution {
    public bool hasDuplicate(int[] nums) {
        Dictionary<int,int> dict = new Dictionary<int,int>();
        for(int i =0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                return true;
            }
            dict[nums[i]] = i;
        }
        return false;
    }
}