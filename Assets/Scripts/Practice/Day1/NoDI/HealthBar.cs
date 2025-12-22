namespace Practice.Day1.NoDI
{
    public class HealthBar
    {
        private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    public void Initialize(int maxHealth)
    {
        _currentHealth = maxHealth;
    }

    public void Decrease(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }
}
}