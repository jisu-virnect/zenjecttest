namespace Practice.Day1.NoDI
{
    public class DamageCalculator
    {
        private int criticalHitMultiplier = 2;
    
    public int Calculate(int baseDamage )
    {
        return baseDamage * criticalHitMultiplier;
    }
    }
}