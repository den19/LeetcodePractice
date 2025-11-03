namespace SearchA2DMatrix
{
    public class Solution
    {
        /// <summary>
        /// Linear search, simple solution
        /// O(m*n)
        /// O(1)
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrixLinear(int[][] matrix, int target)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == target)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Optimal solution - Binary Search
        /// O(log(m*n)
        /// O(1)
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrixBS(int[][] matrix, int target)
        {
            if(matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int left = 0;
            int right = rows * cols - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // Transform middle index to row and column coordinates
                int rowIndex = mid / cols;
                int colIndex = mid % cols;

                if (matrix[rowIndex][colIndex] == target)
                {
                    return true;
                }
                else if (matrix[rowIndex][colIndex] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }
    }
}
