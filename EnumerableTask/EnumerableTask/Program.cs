using EnumerableTask;

class Program
{
    static void Main()
    {
        var str = "asdasd asdasdas sad asdasdas sadasdasdas s";
        MyStringConverter strings = new MyStringConverter(str);
        foreach (var item in strings)
            Console.WriteLine(item);
            
    }
}