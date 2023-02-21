using LinkedListSelf;

class Program
{
    static void Main()
    {
        MyLinkedlist<int> list1 = new MyLinkedlist<int>();
        list1.AddLast(1);
        list1.AddLast(2);
        list1.AddLast(3);
        list1.AddLast(4);

        list1.DeleteK(3);

        Console.WriteLine(list1);

    }
}