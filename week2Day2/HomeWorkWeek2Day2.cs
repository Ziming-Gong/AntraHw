using System;
namespace projects
{
	public class HomeWorkWeek2Day2
	{
		public HomeWorkWeek2Day2()
		{
		}

        public IList<IList<int>> ThreeSum(int[] nums) {
		IList<IList<int>> ans = new List<IList<int>>();
		int n = nums.Length;
		Array.Sort(nums);
		HashSet<string> set = new HashSet<string>();
		for(int i = 0; i < nums.Length - 2; i ++){
		    int target = - nums[i];
		    for(int j = i + 1; j < nums.Length - 1; j ++){
			String str = Convert.ToString(target) + '_' +Convert.ToString(target - nums[j]);
			if(bs(j + 1, n - 1, nums, target - nums[j]) && !set.Contains(str)){
			    IList<int> cur = new List<int>();
			    cur.Add(nums[i]);
			    cur.Add(nums[j]);
			    cur.Add(target - nums[j]);
			    ans.Add(cur);
			    set.Add(str);

			}
		    }
		}
		return ans;

	    }
	    public bool bs(int l, int r, int[] arr, int target){
		int m;
		while(l <= r){
		    m = (l + r) >> 1;
		    if(arr[m] == target){
			return true;
		    }else if(arr[m] > target){
			r = m - 1;
		    }else{
			l = m + 1;
		    }
		}
		return false;
	    }
    	}
}

