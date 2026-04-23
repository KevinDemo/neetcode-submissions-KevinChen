public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var rows = new HashSet<char>[9];
        var cols = new HashSet<char>[9];
        var boxes = new HashSet<char>[9];

        for(int i = 0; i < 9; i++){
            rows[i] = new HashSet<char>();
            cols[i] = new HashSet<char>();
            boxes[i] = new HashSet<char>();
        }

        for(int i = 0; i< 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
               char ch = board[i][j];
              if (ch == '.') continue;

                int boxId = (i / 3) * 3 + (j / 3);

               if(!rows[i].Add(ch) || !cols[j].Add(ch) || !boxes[boxId].Add(ch))
               {
                    return false;
               }
            }
        }
        return true;
    }
}
