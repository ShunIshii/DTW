using System;

namespace DTW
{
    class simpleDTW
    {
        static float[] arrA = {1.0f ,2.0f ,3.0f};
        static float[] arrB = {4.0f ,5.0f ,6.0f ,7.0f};
        static void Main(string[] args)
        {
            float distance = dtw(arrA, arrB);
            Console.WriteLine("distance = {0}", distance);
        }

        static float dtw(float[] a, float[] b)
        {
            float[,] m = new float[a.Length, b.Length];
            m[0,0] = Math.Abs(arrA[0]-arrB[0]);
            for (int i = 1; i < a.Length; i++){
                m[i,0] = m[i-1,0] + Math.Abs(arrA[i]-arrB[0]);
            }
            for (int j = 1; j < b.Length; j++){
                m[0,j] = m[0,j-1] + Math.Abs(arrB[j]-arrA[0]);
            }
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 1; j < b.Length; j++)
                {
                    m[i,j] = Math.Min(Math.Min(m[i-1,j], m[i,j-1]), m[i-1,j-1]) + Math.Abs(arrA[i]-arrB[j]);
                }
            }
            //printMatrix(m);
            return m[a.Length-1, b.Length-1];
        }

        static void printArray(float[] a)
        {
            int i;
            for (i = 0; i < a.Length-1; i++)
            {
                Console.Write("{0,5:f2} ", a[i]);
            }
            Console.WriteLine("{0,5:f2}", a[i++]);
        }
        static void printMatrix(float[,] m)
        {
            Console.Write("      ");
            printArray(arrB);
            for (int i = 0; i < m.GetLength(0); i++)
            {
                Console.Write("{0,5:f2} ", arrA[i]);
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write("{0,5:f2} ", m[i,j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
