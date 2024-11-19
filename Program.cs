//*****************************************************************************
//** 2461. Maximum Sum of Distinct Subarrays With Length K    leetcode       **
//*****************************************************************************

long long maximumSubarraySum(int* nums, int numsSize, int k) 
{
    long long n = numsSize;
    long long s = 0;
    long long sum = 0;
    int* mm = (int*)calloc(100001, sizeof(int));
    int* c = (int*)calloc(k + 1, sizeof(int));

    for (int i = 0; i < k - 1; i++) 
    {
        int t = mm[nums[i]];
        c[t]--;
        c[++mm[nums[i]]]++;
        sum += nums[i];
    }

    for (int i = k - 1; i < n; i++) 
    {
        int t = mm[nums[i]];
        c[t]--;
        c[++mm[nums[i]]]++;
        sum += nums[i];

        // Check if all elements are unique in the current window
        if (c[1] == k) 
        {
            if (sum > s) 
                s = sum;
        }

        // Slide the window
        int t1 = mm[nums[i - k + 1]];
        c[t1]--;
        c[--mm[nums[i - k + 1]]]++;
        sum -= nums[i - k + 1];
    }

    free(mm);
    free(c);
    return s;
}