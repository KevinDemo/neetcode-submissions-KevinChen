public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        //1. define a dictionary to group the strs using the same char count
        var mapper = new Dictionary<string,List<string>>();
        //2. Loop each str and add the char count string into the mapper
        foreach(var str in strs){
            var charCount = new int[26]; 
            foreach(var c in str) charCount[c-'a']++;

            var charString = string.Join(",", charCount);

            if (!mapper.TryGetValue(charString, out var list))
            {
                list = new List<string>();
                mapper[charString] = list;
            }
            list.Add(str);
        }
        //3. return mapper by group
        return mapper.Values.ToList();
    }
}
