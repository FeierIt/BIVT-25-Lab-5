using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int c;
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                c = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        c++;
                    }
                }
                answer[i] = c;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int min_n, min_i;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                min_i = 0;
                min_n = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min_n > matrix[i, j])
                    {
                        min_i = j;
                        min_n = matrix[i, j];
                    }
                }
                for (int j = min_i;  j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                matrix[i, 0] = min_n;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1), max_n, max_i;
            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                max_n = matrix[i, 0];
                max_i = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max_n)
                    {
                        max_n = matrix[i, j];
                        max_i = j;
                    }
                }
                for (int j = 0; j <= max_i;  j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, max_i + 1] = max_n;
                for (int j = max_i + 1; j < cols; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1), max_i, max_n, s, c, sr;
            for (int i = 0; i < rows; i++)
            {
                max_i = 0;
                max_n = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max_n)
                    {
                        max_n = matrix[i, j];
                        max_i = j;
                    }
                }
                if (max_i == cols - 1)
                    continue;
                s = 0;
                c = 0;
                for (int j = max_i + 1; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        c++;
                    }
                }
                if (c == 0)
                    continue;
                sr = s / c;
                for (int j = 0; j < max_i; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = sr;
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (k < 0 || k >= cols)
                return;
            int[] max_arr = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int max_n = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max_n)
                    {
                        max_n = matrix[i, j];
                    }
                }
                max_arr[i] = max_n;
            }
            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = max_arr[rows - 1 - i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1), max_i, max_n;
            if (array.Length != cols)
                return;
            for (int j = 0; j < cols; j++)
            {
                max_i = 0;
                max_n = matrix[0, j];
                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > max_n)
                    {
                        max_n = matrix[i, j];
                        max_i = i;
                    }
                }
                if (array[j] > max_n)
                {
                    matrix[max_i, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            var row_min = new (int min_r, int min_ri)[rows];
            for (int i = 0; i < rows; i++)
            {
                int min_n = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min_n)
                    {
                        min_n = matrix[i, j];
                    }
                }
                row_min[i] = (min_n, i);
            }
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (row_min[i].min_r < row_min[j].min_r)
                    {
                        var temp = row_min[i];
                        row_min[i] = row_min[j];
                        row_min[j] = temp;
                    }
                }
            }
            int[,] sort_matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int x = row_min[i].min_ri;
                for (int j = 0; j < cols; j++)
                {
                    sort_matrix[i, j] = matrix[x, j];
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = sort_matrix[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return answer;
            }
            int n = matrix.GetLength(0);
            answer = new int[2 * n - 1];
            int r_ind = 0;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--, r_ind++)
            {
                int sum = 0, ind = i, j = 0;
                while (ind < matrix.GetLength(0))
                {
                    sum += matrix[ind, j];
                    j++;
                    ind++;
                }
                answer[r_ind] = sum;
            }
            for (int i = 1; i < matrix.GetLength(0); i++, r_ind++)
            {
                int sum = 0, idx = i, j = 0;
                while (idx < matrix.GetLength(0))
                {
                    sum += matrix[j, idx];
                    j++;
                    idx++;
                }
                answer[r_ind] = sum;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int row = matrix.GetLength(0), col = matrix.GetLength(1);
            if (!(row == col && k >= 0 && k <= col))
            {
                return;
            }
            int idx1 = 0, idx2 = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[idx1, idx2]))
                    {
                        idx1 = i; idx2 = j;
                    }
                }
            }
            int[] r = new int[row];
            for (int i = 0; i < row; i++)
            {
                r[i] = matrix[idx1, i];
            }
            if (idx1 < k)
            {
                for (int i = idx1; i < k; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        matrix[i, j] = matrix[i + 1, j];
                    }
                }

            }
            else
            {
                for (int i = idx1; i > k; i--)
                {
                    for (int j = 0; j < row; j++)
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }
            for (int j = 0; j < row; j++)
            {
                matrix[k, j] = r[j];
            }
            int[] c = new int[row];
            for (int i = 0; i < row; i++)
            {
                c[i] = matrix[i, idx2];
            }
            if (idx2 < k)
            {
                for (int i = idx2; i < k; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        matrix[j, i] = matrix[j, i + 1];
                    }

                }
            }
            else
            {
                for (int i = idx2; i > k; i--)
                {
                    for (int j = 0; j < row; j++)
                    {
                        matrix[j, i] = matrix[j, i - 1];
                    }
                }

            }
            for (int i = 0; i < row; i++)
            {
                matrix[i, k] = c[i];
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int row_a = A.GetLength(0), col_a = A.GetLength(1), row_b = B.GetLength(0), col_b = B.GetLength(1);
            if (col_a !=  row_b)
            {
                return answer;
            }
            answer = new int[row_a, col_b];
            for (int i = 0; i < row_a; i++)
            {
                for (int j = 0; j < col_b; j++)
                {
                    int s = 0;
                    for (int k = 0; k < col_a; k++)
                    {
                        s += A[i, k] * B[k, j];
                    }
                    answer[i, j] = s;
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int row = matrix.GetLength(0), col = matrix.GetLength(1);
            answer = new int[row][];
            for (int i = 0; i < row; i++)
            {
                int c = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }
                answer[i] = new int[c];
                int x = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][x] = matrix[i, j];
                        x++;
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                c += array[i].Length;
            }
            int n = (int)Math.Ceiling(Math.Sqrt(c));
            answer = new int[n, n];
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        int row = ind / n, col = ind % n;
                        answer[row, col] = array[i][j];
                        ind++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}