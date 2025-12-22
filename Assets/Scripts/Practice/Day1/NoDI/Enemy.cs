namespace Practice.Day1.NoDI
{
    public class Enemy
    {
        private int _baseDamage;
        private HealthBar _healthBar;
        private DamageCalculator _damageCalculator;

    public Enemy(int baseDamage, int maxHealth)
    {
        _baseDamage = baseDamage;
        _healthBar = new HealthBar();
        _healthBar.Initialize(maxHealth);
        _damageCalculator = new DamageCalculator();
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