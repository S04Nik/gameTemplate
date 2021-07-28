using UnityEngine;
using UnityEngine.UI;

namespace Stepan.Fight3D.GameScripts.Player
{
    public class HealthSystem : MonoBehaviour
    {
        // реализовать роздробленную структуру MVC - хранение - обработка - представление
        [SerializeField] private Image healthBar;
        private PlayerData _playerData;

        public void Initialize(PlayerData playerData)
        {
            _playerData = playerData;
            healthBar.fillAmount = _playerData.Health / 100;
        }

        public void Hit(float damage)
        {
            _playerData.SetHealth(_playerData.Health - damage);
            FillHealthBar();
        }

        public void FillHealthBar()
        {
            healthBar.fillAmount = _playerData.Health / 100;
        }

    }
}
