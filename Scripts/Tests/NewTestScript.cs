using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // Uniqueness test always returns true until uniqueness code is ready. Must test on range of unique and non unique grids. 
    [Test]
    public void isUnique()
    {
         int[,] sudoku = 
            {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };

        bool isSudUnique = checkUnique(sudoku);

        Assert.AreEqual(isSudUnique, true);
    }

    // returns true by default
    public bool checkUnique(int[,] sudoku)
    {
        return true;
    }
    
     // this test is faulty. Attempts to test if a given sudoku is valid.

    [Test]
        public void SymmetryTest()
        {
            int[,] sudoku = 
            {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };

            int[,] symGrid = 
            {
                {8,1,6,3,5,7,4,9,2},
                {3,5,7,4,9,2,8,1,6},
                {4,9,2,8,1,6,3,5,7},
                {7,4,3,1,6,9,2,8,5},
                {1,6,9,2,8,5,7,4,3},
                {2,8,5,7,4,3,1,6,9},
                {9,2,1,6,3,4,5,7,8},
                {6,3,4,5,7,8,9,2,1},
                {5,7,8,9,2,1,6,3,4}
            };

            bool result = IsSudokuSymmetric(sudoku);

            Assert.IsTrue(result);
        }
        private bool IsSudokuSymmetric(int[,] grid)
        {
            int length = grid.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (grid[i, j] != grid[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    

    // tests if a given grid is valid in terms of each number occuring once in each row column and box. 
    [Test]
    public void isValidGrid()
    {
        int[,] grid =
            {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };
       
            bool isvalid = checkValidity(grid);
            Assert.AreEqual(isvalid, true);
        
    }
    private bool checkValidity(int[,] grid)
    {
        bool isvalid = true;
        for (int i = 0; i < 9; i++)
        {
            bool[] row = new bool[10];
            bool[] col = new bool[10];

            for (int j = 0; j < 9; j++)
            {
                if(row[grid[i,j]] & grid[i, j] > 0)
                {
                    isvalid =  false;
                }
                row[grid[i, j]] = true;

                if (col[grid[j, i]] & grid[j, i] > 0)
                {
                    isvalid = false;
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
                                isvalid = false;
                            }
                            sqr[grid[m, n]] = true;
                        }
                    }
                }

            }
            
        }
        return isvalid;
    }

    // Test two given grids are equal ignoring 0's
    [Test]
    public void testCorrectInput()
    {
            int[,] solutionGrid =
            {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };

            int[,] userGrid =
            {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };

            bool areGridsEqual = true;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (solutionGrid[i, j] != 0 && userGrid[i, j] != solutionGrid[i, j])
                    {
                        areGridsEqual = false;
                        break;
                    }
                }

                if (!areGridsEqual)
                {
                    break;
                }
            }

            Assert.IsTrue(areGridsEqual, "Grids are not equal, ignoring 0's.");
        }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
