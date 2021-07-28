namespace Stepan.Fight3D.GameScripts.Enemy
{
    public class EnemyData
    {
        public float Health { get; private set; } // изменить может только playerData - сокрытие данных 

        public EnemyData()
        {
            Health = 100;
        }

        public void SetHealth(float health)
        {
            Health = health;
        }
    }
}