using CollectionClassDelegate;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        FithMethod();
    }

    public static void FirstMethod()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var collectionClass = new CollectionClass<int>(list);
        var result = collectionClass.Aggreagete<int>((x, y) => x + y);
        Console.WriteLine(result);
    }

    public static void SecondMethod()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var collectionClass = new CollectionClass<int>(list);
        var result = collectionClass.Aggreagete<int>((x, y) => x - y);
        Console.WriteLine(result);
    }

    public static void ThirdMethod()
    {
        var list = new List<string> { "1", "2", "5", "23", "24" };
        var collectionClass = new CollectionClass<string>(list);
        var result = collectionClass.Aggreagete<string>((x, y) => x + y);
        var res = collectionClass.Count(x => x.StartsWith("2"));
        Console.WriteLine(result);
        Console.WriteLine(res);
    }

    public static void FourdMethod()
    {
        var list = new List<string> { "1", "2", "5", "23", "24" };
        var collectionClass = new CollectionClass<string>(list);
        var result = collectionClass.Aggreagete<string>((x, y) => $"{x} : {y}");
        Console.WriteLine(result);
    }

    public static void FithMethod()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var collectionClass = new CollectionClass<int>(list);
        var result = collectionClass.Aggreagete<int>((x, y) => x * 2 + y * 2);
        Console.WriteLine(result);
    }
}