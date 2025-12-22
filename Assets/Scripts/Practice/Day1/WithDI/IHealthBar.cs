
namespace Practice.Day1.WithDI
{
    public interface IHealthBar
    {
        int CurrentHealth{ get; }

        void Initialize(int maxHealth);

        void Decrease(int amount);
    }
}