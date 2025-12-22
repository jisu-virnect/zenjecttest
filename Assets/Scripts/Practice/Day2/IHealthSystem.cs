namespace Practice.Day2
{
    public interface IHealthSystem
    {
        int CurrentHealth { get; }
        void Heal(int amount);
    }
}