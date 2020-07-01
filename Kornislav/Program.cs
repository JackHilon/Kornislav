using System;

namespace Kornislav
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kornislav 
            // https://open.kattis.com/problems/kornislav 
            // Kornislav rectangle max area

            var myParameters = Enter4Numbers();
            Console.WriteLine(MaxArea(myParameters));
        }
        private static int[] Enter4Numbers()
        {
            var arr = new string[4];
            var res = new int[4];
            try
            {
                arr = Console.ReadLine().Split(' ', 4);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
                if (NumbersConditions(res) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enter4Numbers();
            }
            return res;
        }
        private static bool NumbersConditions(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] >= 100)
                    return false;
            }
            return true;
        }
        private static bool RectangleIsClosed(int[] points)
        {
            int A = points[0];
            int B = points[1];
            int C = points[2];
            int D = points[3];

            if (D < B || C > A)
                return false;
            else
                return true;
        }
        private static double MaxArea(int[] points)
        {
            int A = points[0];
            int B = points[1];
            int C = points[2];
            int D = points[3];
            if (RectangleIsClosed(points) == true)
                return (double)(Math.Min(A, C) * Math.Min(B, D));
            else
            {
                // if rectangle is not closed, do this! (why? I do not know!!)
                points = BubbleSort(points);
                return points[0] * points[2]; 
            }
            // ---------------------------------------------------------------
            /*
            else if (RectangleIsClosed(points) == false && A == C)
                return (double)A * Math.Max(B, D);
            else if (RectangleIsClosed(points) == false && B == D)
                return (double)B * Math.Max(A, C);
            else if (RectangleIsClosed(points) == false && A < C && B < D)
                return (double)C * (D - B) / 2;
            else if (RectangleIsClosed(points) == false && A < C && B > D)
                return (double)(C - A) * (B - D) / 2;
            else if (RectangleIsClosed(points) == false && A > C && B > D)
                return (double)(A - C) * B / 2;
            else if (RectangleIsClosed(points) == false && A > C && B < D)
                return (double)C * B;//rec is closed here?!
            else
                return Math.Min(A, C) * Math.Min(B, D); // I do not know this case. I add this keddah!?
        */
            //----------------------------------------------------------------------------------
        }

        //========================== Bubble Sort ===============================================
        private static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int k = 1; k < arr.Length; k++)
                {
                    if (arr[k] < arr[k - 1])
                        SwapIntArray(arr, k);
                }
            }
            return arr;
        }
        private static void SwapIntArray(int[] array, int yourIndex)
        {
            int temp = array[yourIndex];
            array[yourIndex] = array[yourIndex - 1];
            array[yourIndex - 1] = temp;
        }
    }
}
