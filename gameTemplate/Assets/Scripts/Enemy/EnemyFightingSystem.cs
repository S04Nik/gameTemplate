using DefaultNamespace;
using Stepan.Fight3D.GameScripts.Player;
using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Enemy
{
    public class EnemyFightingSystem : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationSystem animSystem;
        private PlayerController _playerController;
        private float _damage = 50;
        private float _weakDamage = 10;  // !! ENEMY DATA 
        private EnemyStateController _stateController;
        private float PauseBetweenHits=1.8f;
        private float TimeSinceLastHit=2f;

        public void Initialize(EnemyStateController stateController)
        {
            _stateController = stateController;
        }

        public void Attack()
        {
            if (TimeSinceLastHit >= PauseBetweenHits)
            {
                animSystem.IdleWaitFinish();
                animSystem.AttackStart();
                TimeSinceLastHit = 0;
            }
            else
            {
                if (!animSystem.AttackBool())
                {
                    animSystem.IdleWait();
                    TimeSinceLastHit += Time.deltaTime;
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_stateController.CanMakeHit )
            {
                if (other.CompareTag(Consts.PLAYER_TAG)) // через тег 
                {
                    if (_playerController == null)
                    {
                        _playerController = other.GetComponent<PlayerController>();
                    }
                    _playerController.TakeDamage(_damage);
                }else if (other.name == "Fireaxe 03") // weapon (оружие наслудетс от базовго класса) проверка через компонент
                {
                    if (_playerController == null)
                    {
                        _playerController = other.GetComponentInParent<PlayerController>();
                    }
                    _playerController.TakeDamage(_weakDamage);
                }
                _stateController.CanMakeHit = false;
            }
            
        }
    }
}