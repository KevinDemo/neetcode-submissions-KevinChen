public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>();
        for(int i = 0; i < strs.Length; i++){
            if(dict.ContainsKey(GetFingerprint(strs[i])))
            {
                dict[GetFingerprint(strs[i])].Add(strs[i]);
            }
            else{
                dict.Add(GetFingerprint(strs[i]), new List<string>{ strs[i] });
            }
        }
        return dict.Values.ToList(); 
    }

    private string GetFingerprint(string s)
    {
        int[] counts = new int[26];

        for(int j = 0; j < s.Length; j++){
            int position = (int)s[j] - (int)'a' ;
            counts[position]++;
        }

        return string.Join(",",counts);
    }
}
