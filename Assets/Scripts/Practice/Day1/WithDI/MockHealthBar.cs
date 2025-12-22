namespace Practice.Day1.WithDI
{
    public class MockHealthBar : IHealthBar
    {
        public int InitializeCallCount;
        public int DecreaseCallCount;

        public int TotalDamageTaken;

        private int _fakeHealth = 100;
        public int CurrentHealth => _fakeHealth;
        public void Initialize(int maxHealth)
        {
            InitializeCallCount++;
            _fakeHealth = maxHealth;
            UnityEngine.Debug.Log($"[Mock] Initialize 호출: {maxHealth}");
        }

        public void Decrease(int amount)
        {
            DecreaseCallCount++;
            TotalDamageTaken += amount;
            _fakeHealth -= amount;
            if(_fakeHealth < 0)
            {
                _fakeHealth = 0;
            }
            UnityEngine.Debug.Log($"[Mock] Decrease 호출: {amount}, 총 데미지: {TotalDamageTaken}");
        }
    }
}