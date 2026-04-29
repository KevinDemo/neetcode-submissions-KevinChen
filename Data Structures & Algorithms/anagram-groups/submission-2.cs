public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        //1. define a dictionary to group the strs using the same char count
        var mapper = new Dictionary<string,List<string>>();
        //2. Loop each str and add the char count string into the mapper
        foreach(var str in strs){
            var charCount = new int[26]; 
            for(int i = 0; i < str.Length; i++)
            {
                var charPosition = (char)str[i] - (char)'a';
                charCount[charPosition]++;
            }
           
           var charString = string.Join(",", charCount);
            if(mapper.ContainsKey(charString))
            {
                mapper[charString].Add(str);
            }
            else
            {
                mapper[charString] = new List<string>{str};
            }
        }
        //3. return mapper by group
        return mapper.Values.ToList();
    }
}
