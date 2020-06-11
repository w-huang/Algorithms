public class Solution {
    public int NumIslands(char[][] grid) {
        int ans = 0; //ans could be zero if entire grid is 0

        bool[][] visited = new bool[grid.Length][grid[0].Length] 

        for (var i = 0; i < grid.Length; ++i) {
            for (var j = 0; j < grid[0].Length; ++j) {
                if (!visited[i][j] && grid[i][j] == '1') {
                    dfs(grid, i, j, visited);
                    ans++;
                }
            }
        }
    }

    public void dfs(char[][] grid, i, j, visited) {
        Stack<int[]> st = new Stack<int[]>(); //graph locations, edges are the 4 cartesian directions
        st.Push(new int[] {i, j});

        while (st.Count > 0) {
            int[] node = st.Pop();
            
            if ( node[0] < 0 
                    || grid.Length <= node[0] 
                    || grid[0].Length <= node[1]
                    || node[1] < 0
                    || char[node[0]][node[1]] == '0' ) {
                //Do not try to DFS water tiles
                continue;
            }

            visited[node[0]][node[1]] = true; // mark as visited
            st.Push( new int[] {node[0] + 1, node[1]} );
            st.Push( new int[] {node[0] - 1, node[1]} );
            st.Push( new int[] {node[0], node[1] + 1} );
            st.Push( new int[] {node[0], node[1] - 1} );
        }

        return;

    }
}
