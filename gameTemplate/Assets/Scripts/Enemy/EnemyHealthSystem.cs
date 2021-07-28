using System;
using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Enemy
{
    public class EnemyHealthSystem : MonoBehaviour
    {
        public event Action OnDied;

        public bool isAlive
        {
            get { return !(_enemyData.Health <= 0); }
        }

        private EnemyData _enemyData;
        private EnemyStateController _enemyState;
        
        public void Initialize(EnemyData enemyData,EnemyStateController enemyState)
        {
            _enemyData = enemyData;
            _enemyState = enemyState;
            //healthBar.fillAmount = _playerData.Health / 100;
        }

        public void ReduceHealth(float damage)
        {

            _enemyData.SetHealth(_enemyData.Health - damage);
            if (_enemyData.Health <= 0)
            {
               OnDied?.Invoke();
            }
            //FillHealthBar();
        }

        public void FillHealthBar()
        {
            //healthBar.fillAmount = _playerData.Health / 100;
        }
    }
}