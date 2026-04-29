public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var lastSeen = new Dictionary<char,int>();
        int left = 0, maxLength = 0;
        for(int right = 0; right < s.Length; right++)
        {
            var c = s[right];
            if(lastSeen.TryGetValue(c, out int preIdx)  && preIdx >= left){
                left = preIdx + 1;
            }
            lastSeen[c] = right;
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
}
