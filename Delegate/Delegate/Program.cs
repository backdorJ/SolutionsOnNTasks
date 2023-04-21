using Delegate;
using System.Text;

class Program
{
    public delegate bool HadleDelegateHappyNumber(int a);
    public delegate int HadleDelegateDiv(int a, int b);
    public delegate int HadleDelegateMult(int a, int b);
    public delegate void OpenOrCreateFileAndWrite(string path, string text);

    static void Main()  
    {
        Predicate<string> predicate = (message) =>
        {
            return message.Length % 2 == 0;
        };
    }

}