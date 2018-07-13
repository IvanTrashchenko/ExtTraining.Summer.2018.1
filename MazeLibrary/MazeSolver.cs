using System;

namespace MazeLibrary
{
    public class MazeSolver
    {
        private readonly int[,] mazeModel;

        private int startX;

        private int startY;

        private int[,] mazeWithPass;

        public MazeSolver(int[,] mazeModel, int startX, int startY)
        {

            if (mazeModel == null)
            {
                throw new ArgumentNullException(nameof(mazeModel));
            }

            if (startX < 0 || startX > mazeModel.GetLength(0) - 1)
            {
                throw new ArgumentException(nameof(startX));
            }

            if (startY < 0 || startY > mazeModel.GetLength(1) - 1)
            {
                throw new ArgumentException(nameof(startY));
            }

            this.mazeModel = mazeModel;
            this.startX = startX;
            this.startY = startY;
        }

        public int[,] MazeWithPass() => this.mazeWithPass;

        public void PassMaze()
        {
            int[,] result = mazeModel;

            int k = 1;

            result[startX, startY] = k;

            bool CanLeft()
            {
                if (startY != 0 && result[startX, startY - 1] == 0)
                {
                    return true;
                }
                return false;
            }

            bool CanRight()
            {
                if (startY != result.GetLength(1) - 1 && result[startX, startY + 1] == 0)
                {
                    return true;
                }
                return false;
            }

            bool CanUp()
            {
                if (startX != 0 && result[startX - 1, startY] == 0)
                {
                    return true;
                }
                return false;
            }

            bool CanDown()
            {
                if (startX != result.GetLength(0) - 1 && result[startX + 1, startY] == 0)
                {
                    return true;
                }
                return false;
            }

            void GoLeft()
            {
                startY -= 1;
                k++;
                result[startX, startY] = k;
            }

            void GoRight()
            {
                startY += 1;
                k++;
                result[startX, startY] = k;
            }

            void GoUp()
            {
                startX -= 1;
                k++;
                result[startX, startY] = k;
            }

            void GoDown()
            {
                startX += 1;
                k++;
                result[startX, startY] = k;
            }


            while (true)
            {
                if (CanLeft()) GoLeft();
                else
                {
                    if (CanRight()) GoRight();
                    else
                    {
                        if (CanUp()) GoUp();
                        else
                        {
                            if (CanDown()) GoDown();
                            else break;
                        }
                    }
                }
            }

            this.mazeWithPass = result;
        }
    }
}