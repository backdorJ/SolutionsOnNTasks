namespace StrategyPattern;

public class Boom : IAttack
{
    public void Attack()
    {
        Console.WriteLine("Пиздит вантузом!");
    }
}