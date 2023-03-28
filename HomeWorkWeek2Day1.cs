using System;
namespace projects
{
	public class HomeWorkWeek2Day1
	{
		public HomeWorkWeek2Day1()
		{

		}
        public int[] TwoSum(int[] nums, int target)
        {
            int left = 0;
            int right = 0;

            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(nums[0], 0);
            for (int i = 1; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    return new int[] { map[target - nums[i]], i };
                }
                map.TryAdd(nums[i], i);
            }
            return new int[2];

        }

        public IList<string> FizzBuzz(int n)
        {
            IList<string> ans = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    ans.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    ans.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    ans.Add("Buzz");
                }
                else
                {
                    ans.Add(Convert.ToString(i));
                }
            }

            return ans;
        }
        public bool IsPalindrome(int x)
        {
            string str = Convert.ToString(x);
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }
            return true;
        }
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    return true;
                }
                set.Add(nums[i]);
            }
            return false;
        }
    }

    
}

