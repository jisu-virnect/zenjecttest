using UnityEngine;

namespace Practice.Day1.NoDI
{
    public class EnemyTest : MonoBehaviour
    {
    void Start()
    {
        Enemy enemy = new Enemy(10, 100);
        enemy.Hit(5);
        enemy.Hit(5);
        enemy.Hit(5);
        enemy.ShowHealth();
    }
    }
}