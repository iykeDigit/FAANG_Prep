using System;
using System.Security.Cryptography.X509Certificates;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var letters = new char[]{'e', 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n','n', 'n' };
            var result = NextGreatestLetter(letters, 'e');
            Console.WriteLine();
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

