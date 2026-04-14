public class Solution {

     public string Encode(IList<string> strs) {
        string res = "";
        foreach (string s in strs) {
            res += s.Length + "#" + s;
        }
        return res;
    }

    public List<string> Decode(string s) {
        List<string> res = new List<string>();
        int i = 0;

        while (i < s.Length) {
            // Step 1: Find '#' to get the length
            int j = i;
            while (s[j] != '#') {
                j++;
            }

            // Step 2: Parse length
            int length = int.Parse(s.Substring(i, j - i));

            // Step 3: Extract the string (skip the '#')
            i = j + 1;
            res.Add(s.Substring(i, length));

            // Step 4: Move to next encoded string
            i += length;
        }

        return res;
    }
}
