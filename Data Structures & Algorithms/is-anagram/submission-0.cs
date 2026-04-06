public class Solution {
  public bool IsAnagram(string s, string t){
    if(s.Length != t.Length) return false;
    Dictionary<char, int> dict = new Dictionary<char,int>();
    for(int i = 0; i < s.Length; i ++)
    {
        if(dict.ContainsKey(s[i]))
        {
            dict[s[i]]++;
        }
        else{
            dict[s[i]] = 1;
        }
    }

    for(int j = 0; j < t.Length; j ++){
        if(dict.ContainsKey(t[j]))
        {
            dict[t[j]]--;
            if(dict[t[j]]< 0)
            {
                return false;
            }
        }
        else{
            return false;
        }
    }

    return true;
  }
}
