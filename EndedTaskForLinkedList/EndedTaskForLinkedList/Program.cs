using EndedTaskForLinkedList;

class Program
{
    static void Main()
    {
        var list = new OrderedList<int>();

        list.Add(1);
        list.Add(2);
        Console.WriteLine(list);

        var list2 = new OrderedList<int>();
        list2.Add(-1);
        list2.Add(1);
        Console.WriteLine(list2);

        list.MergeLinkedList(list2);
        list.Delete(-1);

        Console.WriteLine(list);
    }
}