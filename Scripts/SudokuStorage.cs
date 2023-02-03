using System;

namespace Sudoku
{
    class SudokuStorage
    {
        private int[,] grid;

        public int[,] Generate()
        {
            grid = new int[9, 9];
            GenerateSudoku(0, 0);
            return grid;
        }

        private bool GenerateSudoku(int row, int col)
		{
    		if (row == 9)
    		{
        		return true;
    		}

   		 	if (col == 9)
    		{
        		return GenerateSudoku(row + 1, 0);
    		}

    		if (grid[row, col] != 0)
    		{
        		return GenerateSudoku(row, col + 1);
    		}

    		var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    		numbers = ShuffleArray(numbers);

    		for (int i = 0; i < 9; i++)
    		{
        		int num = numbers[i];

        		if (IsValid(row, col, num))
        		{
        			grid[row, col] = num;

            		if (GenerateSudoku(row, col + 1))
            		{
                		return true;
            		}

            		grid[row, col] = 0;
       		 }
    		}

    		return false;
		}

		private int[] ShuffleArray(int[] array)
		{
    		Random random = new Random();

    		for (int i = array.Length - 1; i > 0; i--)
    		{
        		int j = random.Next(0, i + 1);
        		int temp = array[i];
        		array[i] = array[j];
        		array[j] = temp;
    		}

    		return array;
		}

        private bool IsValid(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, col] == num || grid[row, i] == num)
                {
                    return false;
                }
            }

            int startRow = row - row % 3;
            int startCol = col - col % 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i + startRow, j + startCol] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

		public int[,] RemoveCells(int[,] grid, int difficulty)
		{
    		Random random = new Random();
    		int cellsToRemove = (81 - 35) / 2; // Number of cells to remove, based on difficulty

    		while (cellsToRemove > 0)
    		{
        		int row = random.Next(0, 9);
        		int col = random.Next(0, 9);

        		if (grid[row, col] != 0)
        		{
            		grid[row, col] = 0;
            		grid[8 - row, 8 - col] = 0;
            		cellsToRemove--;
        		}
    		}


    		return grid;
		}

		public bool Validate(int[,] grid)
    {
        for (int i = 0; i < 9; i++)
        {
            bool[] row = new bool[10];
            bool[] col = new bool[10];

            for (int j = 0; j < 9; j++)
            {
                if(row[grid[i,j]] & grid[i, j] > 0)
                {
                    return false;
                }
                row[grid[i, j]] = true;

                if (col[grid[j, i]] & grid[j, i] > 0)
                {
                    return false;
                }
                col[grid[j, i]] = true;

                if ((i + 3) % 3 == 0 && (j + 3) % 3 == 0)
                {
                    bool[] sqr = new bool[10];
                    for (int m = i; m < i + 3; m++)
                    {
                        for (int n = j; n < j + 3; n++)
                        {
                            if (sqr[grid[m, n]] & grid[m, n] > 0)
                            {
                                return false;
                            }
                            sqr[grid[m, n]] = true;
                        }
                    }
                }

            }
        }
        return true;
    }
    }
}
