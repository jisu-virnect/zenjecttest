using UnityEngine;

namespace Practice.Day1.WithDI
{
    public class EnemyTest : MonoBehaviour
    {
        void Start()
        {
            TestWithRealHealthBar();
            Debug.Log("==================");
            TestWithMockHealthBar();
        }

        private void TestWithRealHealthBar()
        {
            Debug.Log("=== 실제 HealthBar 테스트 ===");
            Enemy enemy = new Enemy(new HealthBar(), new DamageCalculator(), 100);
            enemy.Hit(5);
            enemy.Hit(5);
            enemy.Hit(5);
            enemy.ShowHealth();
        }

        private void TestWithMockHealthBar()
        {
            Debug.Log("=== Mock HealthBar 테스트 ===");
            var mockHealthBar = new MockHealthBar();
            var damageCalculator = new DamageCalculator();
            Enemy enemy = new Enemy(mockHealthBar, damageCalculator, 100);
            enemy.Hit(5);
            enemy.Hit(5);
            enemy.Hit(5);

            Debug.Log("[검증] Initialize 호출 횟수: " + mockHealthBar.InitializeCallCount);
            Debug.Log("[검증] Decrease 호출 횟수: " + mockHealthBar.DecreaseCallCount);
            Debug.Log("[검증] 총 데미지: " + mockHealthBar.TotalDamageTaken);
            Debug.Log("[검증] 최종 체력: " + mockHealthBar.CurrentHealth);
        }
    }
}