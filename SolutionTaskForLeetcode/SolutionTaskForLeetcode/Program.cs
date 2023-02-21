class Program
{
    static void Main()
    {
        ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
    }

    public static void ReverseString(char[] s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            var temp = s[i];
            s[i] = s[s.Length - 1 - i];
            s[s.Length - 1 - i] = temp;
        }
    }
}