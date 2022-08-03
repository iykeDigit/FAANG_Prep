using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SlidingWindowTechnique
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1,2,1,4, 4, 4, 4, 5};
           
            var x = UniqueChars("ABCA");
            Console.WriteLine();
        }

        public static int UniqueChars(string s)
        {
            Dictionary<char, List<int>> dict = new Dictionary<char, List<int>>();

            int res = 0, N = s.Length;

            for (int i = 0; i < N; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    var list = dict[s[i]];
                    list.Add(i);
                }
                else
                {
                    dict.Add(s[i], new List<int> { i });
                }
            }


            foreach (var item in dict.Values)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    var left = i == 0 ? 1 + item[i] : item[i] - item[i - 1];
                    var right = i == item.Count - 1 ? N - item[i] : item[i + 1] - item[i];

                    res += (left * right);
                }
            }

            return res;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var max = int.MinValue;
            var set = new HashSet<char>(); 
            var last = 0;
            var first = 0;
            
                while(first < s.Length)
            {
                if (!set.Contains(s[first]))
                {
                    set.Add(s[first]);
                    first++;
                    max = Math.Max(set.Count, max);
                }

                else
                {
                    set.Remove(s[last]);
                    last++;
                }
            }

            return max;
        }
        public static int CharacterReplacement(string s, int k)
        {
            var left = 0;
            var maxf = int.MinValue;
            var result = 0;
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict[s[i]] = 1;
                }
                else
                {
                    dict[s[i]]++;
                }

                maxf = Math.Max(maxf, dict[s[i]]);

                while((i - left + 1) - maxf > k)
                {
                    dict[s[left]]--;
                    left++;
                }
                result = Math.Max(result, i - left + 1);
            }

            return result;
        }

        public static bool CheckInclusion(string T, string S)
        {
            int[] dic = new int[26];
            int i = 0;
            int j = 0;
            int count = 0;
            string ans = string.Empty;
            for (int k = 0; k < T.Length; k++)
            {
                dic[T[k] - 'a']++;
            }

            while (j < S.Length)
            {
                dic[S[j] - 'a']--;

                if (dic[S[j] - 'a'] >= 0)
                {
                    count++;
                }

                while (count == T.Length)
                {
                    int val = j - i + 1;

                    if (T.Length == val)
                    {
                        return true;
                    }

                    dic[S[i] - 'a']++;

                    if (dic[S[i] - 'a'] > 0)
                    {
                        count--;
                    }

                    i++;
                }

                j++;
            }

            return false;
        }
        public static bool CheckInclusionB(string T, string S)
        {
            var dicT = new int[26];
            var dicS = new int[26];
            var start = 0;
            var count = 0;

            Console.WriteLine(S[0]);

            foreach (var item in T)
            {
                dicT[item - 'a']++;
            }

            foreach (var x in S)
            {
                dicS[x - 'a']++;
                count++;
                while (count == T.Length)
                {
                    if (dicT.SequenceEqual(dicS))
                    {
                        return true;
                    }

                    dicS[S[start] - 'a']--;
                    start++;
                    count--;
                }
            }
            return false;
        }
        
        public static int MaxSumSubArray(int[] arr, int k)
        {
            int maxValue = Int32.MinValue;
            int currentRunningSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentRunningSum += arr[i];
                if (i >= k - 1)
                {
                    maxValue = Math.Max(maxValue, currentRunningSum);
                    currentRunningSum -= arr[i - (k - 1)];
                }
            }

            return maxValue;
        }

        public static int SmallestSubArray(int targetSum, int[] arr)
        {
            int minWindowSize = int.MaxValue;
            int currentWindowSum = 0;
            int windowStart = 0;

            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                currentWindowSum += arr[windowEnd];

                while (currentWindowSum >= targetSum)
                {
                    minWindowSize = Math.Min(minWindowSize, windowEnd - windowStart + 1);
                    currentWindowSum -= arr[windowStart];
                    windowStart++;
                }
            }

            return minWindowSize;
        }

        public static int LongestDistinctSubstring(string strArr)
        {
            var maxLength = int.MinValue;
            var windowStart = 0;
            int currentLength = 0;
            var dict = new Dictionary<char, int>();

            foreach (var t in strArr)
            {
                if (dict.ContainsKey(t))
                {
                    dict[t]++;
                }

                else
                {
                    dict[t] = 1;
                }

                if (dict.Count > 2)
                {
                    while (dict.Count > 2)
                    {
                        dict[strArr[windowStart]]--;
                        if (dict[strArr[windowStart]] == 0)
                        {
                            dict.Remove(strArr[windowStart]);
                        }

                        windowStart++;
                    }

                    continue;
                }

                currentLength = dict.Values.Sum();
                maxLength = Math.Max(maxLength, currentLength);
            }

            return maxLength;
        }

        public static int MinSubArrayLen(int target, int[] arr)
        {
            var minLength = int.MaxValue;
            var windowStart = 0;
            var currentSum = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];
             
                if (currentSum >= target)
                {
                    while (currentSum >= target)
                    {
                        minLength = Math.Min(minLength, i-windowStart +1);
                        currentSum -= arr[windowStart];
                        windowStart++;
                    }
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }

        public static int TotalFruit(int[] fruits)
        {
            var dict = new Dictionary<int, int>();
            var currentMax = 0;
            var windowStart = 0;

            //[3,3,3,1,2,1,1,2,3,3,4

            foreach (var fruit in fruits)
            {
                if (dict.ContainsKey(fruit))
                {
                    dict[fruit]++;
                }

                else
                {
                    dict[fruit] = 1;
                }

                if (dict.Count > 2)
                {
                    while (dict.Count > 2)
                    {
                        dict[fruits[windowStart]]--;
                        if (dict[fruits[windowStart]] == 0)
                        {
                            dict.Remove(fruits[windowStart]);
                        }

                        windowStart++;
                    }

                    continue;
                }
                currentMax = Math.Max(currentMax, dict.Values.Sum());
            }
            
            return currentMax;
        }

        public static int TotalFruits(int[] fruits)
        {
            int max = 0;
            int lastFruit = -1;
            int secondLastFruit = -1;
            int lastFruitCount = 0;
            int currentMax = 0;

            foreach (int fruit in fruits)
            {
                if (fruit == lastFruit || fruit == secondLastFruit)
                {
                    currentMax += 1;
                }

                else
                {
                    currentMax = lastFruitCount + 1;
                }

                if (fruit == lastFruit)
                {
                    lastFruitCount++;
                }
                else
                {
                    lastFruitCount = 1;
                }

                if (lastFruit != fruit)
                {
                    secondLastFruit = lastFruit;
                    lastFruit = fruit;
                }

                max = Math.Max(max, currentMax);

            }
            return max;
        }

        public static bool IsAnagram(string a, string b)
        {
            if (a.Length != b.Length) return false;

            var first = new int[26];
            var second = new int[26];

            for (int i = 0; i < a.Length; i++)
            {
                var indexOne = a[i] - 'a';
                first[indexOne] += 1;
                var indexTwo = a[i] - 'a';
                second[indexTwo] += 1;
            }

            return first.SequenceEqual(second);
        }

       public static bool IsAnaGramTwo(string val1, string val2)
        {
            var total1 = 0;
            var total2 = 0;

            if (val1.Length != val2.Length)
            {
                return false;
            }
            var len = val2.Length;

            for (int i = 0; i < len; i++)
            {
                total1 += (int)val1[i];
                total2 += (int)val2[i];
            }

            return total1 == total2 ? true : false;
        }

    }
}
