using ConsoleApp2;

class Program
{
    static void Main()
    {
        var max = new MaxMin(5);
        max.PrintMatrix();
        var s = max.GetMax();

        Console.WriteLine(s);
    }
}