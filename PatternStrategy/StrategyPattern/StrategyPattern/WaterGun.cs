namespace StrategyPattern;

public class WaterGun : IAttack
{
    public void Attack()
    {
        Console.WriteLine("Ебашит с пистолеат (водяного)");
    }
}