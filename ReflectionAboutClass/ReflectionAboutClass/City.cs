namespace ReflectionAboutClass;

public class City : Government
{
    private int _countPeoplesPrivateField = 0;
    public int _countPeoplesPublicField = 0;
    public static int _countPeoplesPublicAndStatic = 0;

    public string TypeCity { get; set; }
    private int BankCity { get; set; }

    public string GetAmountCity() => $"BankCity is - {BankCity}";
    
    public static string GetCountPeoplesFromCity()
        => $"Count peoples static {_countPeoplesPublicAndStatic}";

    public City(int countPeoples)
    {
        _countPeoplesPrivateField = countPeoples;
        Console.WriteLine("Invoke constructor countPeoplesPrivateField");
    }

    public City()
    {
        Console.WriteLine("Invoke no parameters constructor");
    }

    public City(string typeCity)
    {
        TypeCity = typeCity;
    }
}