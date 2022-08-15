using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var letters = new char[]{'e', 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n','n', 'n' };
            var nums = new int[] {1, 3, 4, 2, 2};
            var result = FindDuplicate(nums);
            Console.WriteLine();
        }

        public static int FindDuplicate(int[] nums)
        {
            int low = 1, high = nums.Length - 1;
            int duplicate = -1;

            while (low <= high)
            {
                int cur = (low + high) / 2;

                // Count how many numbers in 'nums' are less than or equal to 'cur'
                int count = 0;
                foreach (int num in nums)
                {
                    if (num <= cur)
                        count++;
                }

                if (count > cur)
                {
                    duplicate = cur;
                    high = cur - 1;
                }
                else
                {
                    low = cur + 1;
                }
            }
            return duplicate;
        }

        public static char NextGreatestLetter(char[] letters, char target)
        {
            int l = 0, r = letters.Length - 1;
            while (l <= r)
            {
                int mid =  (r + l) / 2;
                if (letters[mid] <= target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }

            if (l >= letters.Length) l = 0;
            return letters[l];
        }
    }

}

