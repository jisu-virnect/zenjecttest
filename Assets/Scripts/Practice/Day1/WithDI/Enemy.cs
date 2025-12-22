namespace Practice.Day1.WithDI
{

    
    public class Enemy
    {
        private int _baseDamage;
        private readonly IHealthBar _healthBar;
        private readonly IDamageCalculator _damageCalculator;

        public Enemy(IHealthBar healthBar, IDamageCalculator damageCalculator, int maxHealth)
        {
            _baseDamage = 10;
            _healthBar = healthBar;
            _healthBar.Initialize(maxHealth);
            _damageCalculator = damageCalculator;
        }

        public void Hit(int damage)
        {
            int calculatedDamage = _damageCalculator.Calculate(damage);
            _healthBar.Decrease(calculatedDamage);
        }

        public void ShowHealth()
        {
            UnityEngine.Debug.Log("Current Health: " + _healthBar.CurrentHealth);
        }
    }
}