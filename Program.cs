using System;
using System.Threading;
namespace convolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputImage = new int[,] {
                {128,255,196,64},
                {20,128,255,96},
                {210,20,128,255},
                {210,210,20,128}
            };
            int[,] kernelMatrix = new int[,] {
                {1,2,1},
                {0,0,0},
                {-1,-2,-1},
            };
            int[,] resultArray = new int[4, 4];
            int[,] updatedInputImage = updateInputImageMatrix(inputImage);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int sum = 0;
                    int[,] chunk2dArray = chunk2DArray(updatedInputImage, i, j);
                    for (int row = 0; row < 3; row++)
                    {

                        for (int col = 0; col < 3; col++)
                        {
                            sum += chunk2dArray[row, col] * kernelMatrix[row, col];
                            Console.WriteLine(chunk2dArray[row, col] + " * " + kernelMatrix[row, col]);
                            Thread.Sleep(1000);
                        }
                    }
                    resultArray[i, j] = sum;
                    Console.WriteLine(resultArray[i, j]);
                    Thread.Sleep(1000);

                }
            }
            static int[,] chunk2DArray(int[,] input, int startrow, int startcol)
            {
                int[,] chunckArray = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        chunckArray[i, j] = input[i + startrow, j + startcol];
                    }
                }
                return chunckArray;
            }
            static int[,] updateInputImageMatrix(int[,] inputImageMatrix)
            {
                int[,] updatedInputImage = new int[6, 6];
                for (int row = 0; row < 6; row++)
                {
                    updatedInputImage[row, 0] = 0;
                    updatedInputImage[row, 5] = 0;
                    for (int col = 1; col < 5; col++)
                    {
                        updatedInputImage[0, col] = 0;
                        updatedInputImage[5, col] = 0;
                        for (int x = 1; x < 5; x++)
                        {
                            updatedInputImage[col, x] = inputImageMatrix[col - 1, x - 1];
                        }
                    }
                }
                return updatedInputImage;
            }

        }
    }
}
