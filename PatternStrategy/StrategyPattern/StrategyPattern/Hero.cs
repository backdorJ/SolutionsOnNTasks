namespace StrategyPattern;

public class Hero
{
    public IAttack AttackType { private get; set; }


    public Hero(IAttack attackType)
    {
        AttackType = attackType;
    }

    public void Attack()
    {
        AttackType.Attack();
    }
}