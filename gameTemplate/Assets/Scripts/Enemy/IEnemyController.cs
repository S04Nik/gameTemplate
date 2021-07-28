namespace Stepan.Fight3D.GameScripts.Enemy
{
    public interface IEnemyController 
    {
        void Init(EnemyConfig enemyConfig);
        void TakeDamage(float damage);
    }
}