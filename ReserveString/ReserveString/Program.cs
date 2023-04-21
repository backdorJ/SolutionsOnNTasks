using ReserveString;
using System.Text;

class Program
{
    static void Main()
    {
        Person person = new Person();
    }

    public static int? SingleNumber(int[] nums)
    {
        int? digit = null;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var t = nums[i];
            for (int j = 0; j < nums.Length; j++)
            {
                if (t == nums[j])
                {
                    count++;
                }
            }
        }

        return digit;
    }
}