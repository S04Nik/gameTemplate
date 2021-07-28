using System;
using UnityEngine;

namespace Stepan.Fight3D.GameScripts.Enemy
{
    public class EnemyController : MonoBehaviour , IEnemyController
    { 
        [SerializeField] private EnemyFightingSystem _fightingSystem;
        [SerializeField] private EnemyMovingSystem _movingSystem;
        [SerializeField] private EnemyHealthSystem _healthSystem;
        [SerializeField] private EnemyAnimationSystem animSystem;
        
        private EnemyConfig _enemyConfig;
        private EnemyStateController _stateController;
        private EnemyData _enemyData;
        
        public event Action OnDied;

        public void Init(EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;
            _stateController = new EnemyStateController();
            _enemyData = new EnemyData();
            
            _healthSystem.Initialize(_enemyData,_stateController);
            animSystem.Initialize(_stateController,this);
            _fightingSystem.Initialize(_stateController);
            
            _movingSystem.Initialize(_healthSystem,enemyConfig);
            
            Subscribe();
        }
        
        public void TakeDamage(float damage)
        {
            _healthSystem.ReduceHealth(damage);
            
            if (_enemyData.Health > 0)
                animSystem.StartReceivingHit();
        }

        public void DeInit()
        {
            Unsubscribe();
        }
        
        private void Subscribe()
        {
            _healthSystem.OnDied += EnemyDieHandle;
        }

        private void EnemyDieHandle()
        {
            OnDied?.Invoke();
        }
        
        private void Unsubscribe()
        {
            _healthSystem.OnDied -= EnemyDieHandle;
        }
        
    }
    

}
