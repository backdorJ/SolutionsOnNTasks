using Polinom;

class Program
{
    static void Main()
    {
        Konj ints = new Konj();
        ints.Add(1);
        ints.Add(2);

        //ZhegalkinPolinom zhegalkinPolinom  = new ZhegalkinPolinom("x1x2+1+x2x3");

        ZhegalkinPolinom zhegalkinPolinom1 = new ZhegalkinPolinom("x2x3x4+x1x3+x3");

        var p = zhegalkinPolinom1.PolinomWith(1);
        p.SortByLength();
        Console.WriteLine(p);
    }
}