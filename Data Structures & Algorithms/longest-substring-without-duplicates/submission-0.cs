public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // Loop the string to 
        var set = new HashSet<char>();
        int left = 0;
        int maxLength = 0;
        for(var right = 0; right < s.Length; right++)
        {
            var c = s[right];
            while(set.Contains(c)){
                set.Remove(s[left]);
                left++;
            }
            set.Add(c);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
