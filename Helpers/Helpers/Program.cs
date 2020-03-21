using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 3 ,4, 9};
            int[] arr2 = { 2, 3, 5, 6, 10 };
            int[] arrResult = mergeTwoSortedArrays(arr1, arr2);

            foreach (var item in arrResult)
            {
                Console.WriteLine(item);
            }
            

    }

        public static int[] mergeTwoSortedArrays(int[] nums1, int[] nums2)
        {
            int[] merged = new int[nums1.Length + nums2.Length];

            int pointer1 = 0;
            int pointer2 = 0;
            for (int i = 0; i < merged.Length; i++)
            {
                if ((pointer1 < nums1.Length) && (pointer2 < nums2.Length))
                {
                    if (nums1[pointer1] <= nums2[pointer2])
                    {
                        merged[i] = nums1[pointer1];
                        pointer1++;
                    }
                    else if (nums1[pointer1] > nums2[pointer2])
                    {
                        merged[i] = nums2[pointer2];
                        pointer2++;
                    }
                }
                else if (pointer1 == nums1.Length)
                {
                    for (int k = pointer2; k < nums2.Length; k++, i++)
                    {
                        merged[i] = nums2[k];
                    }
                    break;
                }
                else if (pointer2 == nums2.Length)
                {
                    for (int k = pointer1; k < nums1.Length; k++, i++)
                    {
                        merged[i] = nums1[k];
                    }
                    break;
                }
            }
            return merged;
        }
    }
}
