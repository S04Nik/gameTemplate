namespace Stepan.Fight3D.GameScripts.Player
{
    public class PlayerData
    {
        public float Health { get; private set; } // изменить может только playerData - сокрытие данных 

        public PlayerData()
        {
            Health = 100;
        }

        public void SetHealth(float health)
        {
            Health = health;
        }

    }
}
