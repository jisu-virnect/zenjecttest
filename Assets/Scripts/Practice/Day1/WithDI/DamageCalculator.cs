namespace Practice.Day1.WithDI
{
    public class DamageCalculator : IDamageCalculator
    {
        private int criticalHitMultiplier = 2;
    
        public int Calculate(int baseDamage )
        {
            return baseDamage * criticalHitMultiplier;
        }
    }
}